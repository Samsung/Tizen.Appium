/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#include <iostream>
#include <string>
#include <sstream>
#include <vector>
#include <set>
#include <list>
#include <functional>
#include <boost/tokenizer.hpp>
#include <dbus/dbus.h>
#include <dbus/dbus-glib-lowlevel.h>

#include "log.h"
#include "dbus_utils.h"

#define DBUS_REPLY_TIMEOUT (-1)

using namespace boost;
using namespace std;


std::set<DBusMessage*> DBusMessage::s_objects_;

DBusMessage* DBusMessage::getInstance() {
  _D("Enter");
  static DBusMessage instance;
  return &instance;
}

DBusMessage::DBusMessage() : destination_("org.tizen.appium"), connection_(nullptr) 
{
    s_objects_.insert(this);
}

DBusMessage::~DBusMessage()
{
    if (connection_) {
        dbus_connection_close(connection_);
        dbus_connection_unref(connection_);
    }

    const auto iter = s_objects_.find(this);

    if (s_objects_.end() != iter){
        s_objects_.erase(iter);
    } else {
        _D("Object is not existing in the static pool");
    }
}

void DBusMessage::CheckConnection()
{
    _D("Enter");
    if (!connection_) {
        DBusError err;
        dbus_error_init(&err);

        connection_ = dbus_bus_get(DBUS_BUS_SYSTEM, &err);

        if (dbus_error_is_set(&err)) {
            _D("dbus_bus_get error [%s, %s]", err.name, err.message);
        }
    }

    if (!connection_) {
        return;
    }
}

char* DBusMessage::SendSyncMessage(const std::string& dPath, const std::string& dInterface, 
                                    const std::string& dMethod, char* arguements) 
{

    CheckConnection();
    DBusMessage* msg = dbus_message_new_method_call(
                            destination_.c_str(), dPath.c_str(), dInterface.c_str(), dMethod.c_str());
    if (!msg)
    {
        _D("dbus_message_new_method_call error");
        return 0;
    }
    
    DBusMessageIter args2;
    dbus_message_iter_init_append(msg, &args2);
    dbus_message_iter_append_basic(&args2, DBUS_TYPE_STRING, &arguements);

    DBusError err;
    dbus_error_init(&err);
    DBusMessage* reply = dbus_connection_send_with_reply_and_block(connection_, msg, DBUS_REPLY_TIMEOUT, &err);
    dbus_message_unref(msg);

    if (!reply) 
    {
        _E("dbus_connection_send_with_reply_and_block error %s: %s", err.name, err.message);
        dbus_error_free(&err);
        return 0;
    }

    char* result = 0;
    dbus_bool_t ret = dbus_message_get_args(reply, &err, DBUS_TYPE_STRING, &result, DBUS_TYPE_INVALID);
    dbus_message_unref(reply);

    if (!ret) 
    {
        _D("dbus_message_get_args error %s: %s", err.name, err.message);
        dbus_error_free(&err);
        return 0;
    }
    return strdup(result);
}

std::map<std::string, signalHandler> DBusSignal::signalMap;

DBusSignal::DBusSignal() : connection_(nullptr) 
{
}

DBusSignal::~DBusSignal() 
{
    if (connection_) 
    {
        dbus_connection_close(connection_);
        dbus_connection_unref(connection_);
    }
}

DBusSignal* DBusSignal::getInstance() 
{
  static DBusSignal instance;
  return &instance;
}

int DBusSignal::InitializeConnection()
{

    DBusError err;
    int ret;

    if(connection_ != NULL){
        _D("Dbus connection already created");
        return 0;
    }

    dbus_error_init(&err);
    connection_ = dbus_bus_get(DBUS_BUS_SYSTEM, &err);
    if (dbus_error_is_set(&err)) {
        _D("Dbus error [%s , %s]", err.name, err.message);
        dbus_error_free(&err);
        return -1;
    }

    if (NULL == connection_) {
        _D("Dbus error [%s , %s]", err.name, err.message);
        dbus_error_free(&err);
        return -1;
    }

    // TODO : temporary
    dbus_connection_setup_with_g_main(connection_, nullptr);

    ret = dbus_bus_request_name(connection_, "tizen.restful.signal", DBUS_NAME_FLAG_REPLACE_EXISTING , &err);
    if (dbus_error_is_set(&err)) {
        _D("Dbus error [%s , %s]", err.name, err.message);
        dbus_error_free(&err);
        return -1;
    }

    if (DBUS_REQUEST_NAME_REPLY_PRIMARY_OWNER != ret) {
        _D("Request name already has owner");
    }

    if (dbus_connection_add_filter(connection_, DBusSignalHandler, this, nullptr) == FALSE) {
        _D("Fail to add filter : %s, %s", err.name, err.message);
        dbus_error_free(&err);
        return -1;
    }else{
        _D("Handler registered");
        return 0;
    }

}

DBusHandlerResult DBusSignal::DBusSignalHandler(DBusConnection* conn, DBusMessage* msg, void* user_data)
{
    _D("Enter");
    if (NULL == msg) {
        _D("Message Null");
        return DBUS_HANDLER_RESULT_HANDLED ;
    }

    for (auto iter : signalMap){
        char_separator<char> sep("/");
        tokenizer<char_separator<char>> tokens(iter.first, sep);
        std::list<std::string> pathList(tokens.begin(), tokens.end());

        auto tokenIter = tokens.begin();
        string _interface = *tokenIter;
        tokenIter++;
        string _method = *tokenIter;

        if (dbus_message_is_signal(msg, _interface.c_str(), _method.c_str())) {
            iter.second(msg);
            break;
        }
    }

    _D("End");
    return DBUS_HANDLER_RESULT_HANDLED ;
}

int DBusSignal::RegisterSignal(const std::string& dInterface, const std::string& dMethod, signalHandler callback) 
{
    _D("Enter");
    DBusError err;
    signalHandler _handler;

    if(nullptr == connection_){
        InitializeConnection();
    }

    std::stringstream _ruleStream;
    _ruleStream << "type='signal'" << ",interface='" << dInterface << "'";

    std::string signalRule = _ruleStream.str();

    dbus_error_init(&err);

    dbus_bus_add_match(connection_, signalRule.c_str(), &err); // see signals from the given interface
    dbus_connection_flush(connection_);
    if (dbus_error_is_set(&err)) {
        _D("dbus error : %s", err.message);
        dbus_error_free(&err);
        return -1;
    }

    _handler = std::move(callback);

    std::stringstream _signalKey;
    _signalKey<<dInterface<<"/"<<dMethod;
    std::string signalKey = _signalKey.str();

    auto iter = signalMap.find(signalKey);
    if(iter != signalMap.end()){
        signalMap.erase(iter);
    }
    signalMap[signalKey] = _handler;

    _D("End");
    return 0;
}
