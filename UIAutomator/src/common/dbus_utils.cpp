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
#include <algorithm>
#include <functional>
#include <boost/tokenizer.hpp>
#include <dbus/dbus.h>
#include <dbus/dbus-glib-lowlevel.h>
#include <E_DBus.h>

#include "log.h"
#include "dbus_utils.h"
#include "server/json_utils.h"
#include "server/server.h"

#define DBUS_REPLY_TIMEOUT (-1)

using namespace boost;
using namespace std;


DBusArgument::DBusArgument()
{
}

DBusArgument::~DBusArgument()
{
}


std::set<DBusMessage*> DBusMessage::s_objects_;

DBusMessage* DBusMessage::getInstance() 
{
    static DBusMessage instance;
    return &instance;
}

DBusMessage::DBusMessage() : DBusDestination("org.tizen.appium"), DBusPath("/org/tizen/appium"), 
                             DBusInterface("org.tizen.appium"), DbusConnection(nullptr) 
{
    s_objects_.insert(this);
}

DBusMessage::~DBusMessage()
{
    if (DbusConnection) 
    {
        dbus_connection_close(DbusConnection);
        dbus_connection_unref(DbusConnection);
    }

    const auto iter = s_objects_.find(this);
    if (s_objects_.end() != iter)
    {
        s_objects_.erase(iter);
    } 
    else 
    {
        _D("Object is not existing in the static pool");
    }
}

void DBusMessage::CheckConnection()
{
    if (!DbusConnection) 
    {
        DBusError err;
        dbus_error_init(&err);

        DbusConnection = dbus_bus_get(DBUS_BUS_SYSTEM, &err);
        if (dbus_error_is_set(&err)) 
        {
            _D("dbus_bus_get error [%s, %s]", err.name, err.message);
        }
    }

    if (!DbusConnection) 
    {
        return;
    }
}

void DBusMessage::AddArgument(bool data)
{   
    _D("%s", data?"true":"false");
    DBusArgument arg;
    arg.Type = TypeBool;
    arg.DataBool = data;
    Arguments.push_back(arg);
}

void DBusMessage::AddArgument(int data)
{   
    _D("%d", data);
    DBusArgument arg;
    arg.Type = TypeInt;
    arg.DataInt = data;
    Arguments.push_back(arg);
}

void DBusMessage::AddArgument(char* data)
{   
    _D("%s", data);
    DBusArgument arg;
    arg.Type = TypeString;
    arg.DataString = data;
    Arguments.push_back(arg);
}

void DBusMessage::AddArgument(string data)
{   
    _D("%s", data.c_str());
    DBusArgument arg;
    arg.Type = TypeString;
    arg.DataString = data;
    Arguments.push_back(arg);
}

void DBusMessage::GetReplyMessage(DBusMessage* reply, char** value)
{
    DBusError err;
    dbus_error_init(&err);

    dbus_bool_t ret = dbus_message_get_args(reply, &err, DBUS_TYPE_STRING, value, DBUS_TYPE_INVALID);
    dbus_message_unref(reply);
    if (!ret) 
    {
        _D("dbus_message_get_args error %s: %s", err.name, err.message);
        dbus_error_free(&err);
        return;
    }
    return;
}

void DBusMessage::GetReplyMessage(DBusMessage* reply, int* value)
{
    DBusError err;
    dbus_error_init(&err);

    dbus_bool_t ret = dbus_message_get_args(reply, &err, DBUS_TYPE_INT32, value, DBUS_TYPE_INVALID);
    dbus_message_unref(reply);
    if (!ret) 
    {
        _D("dbus_message_get_args error %s: %s", err.name, err.message);
        dbus_error_free(&err);
        return;
    }
    return;
}

void DBusMessage::GetReplyMessage(DBusMessage* reply, bool* value)
{
    DBusError err;
    dbus_error_init(&err);

    dbus_bool_t ret = dbus_message_get_args(reply, &err, DBUS_TYPE_BOOLEAN, value, DBUS_TYPE_INVALID);
    dbus_message_unref(reply);
    if (!ret) 
    {
        _D("dbus_message_get_args error %s: %s", err.name, err.message);
        dbus_error_free(&err);
        return;
    }
    return;
}

DBusMessage* DBusMessage::SendSyncMessage(string method) 
{
    _D("%s", method.c_str());
    CheckConnection();
    DBusMessage* msg = dbus_message_new_method_call(DBusDestination.c_str(), DBusPath.c_str(), DBusInterface.c_str(), method.c_str());
    if (!msg)
    {
        _D("dbus_message_new_method_call error");
        return 0;
    }
    DBusMessageIter args;
    dbus_message_iter_init_append(msg, &args);
    for(auto cur = Arguments.begin(); cur != Arguments.end(); cur++)
    {
        if((*cur).Type == TypeString)
        {
            char* temp = strdup((*cur).DataString.c_str());
            _D("argument : %s", temp);
            dbus_message_iter_append_basic(&args, DBUS_TYPE_STRING, &temp);
        }
        else if((*cur).Type == TypeInt)
        {
            int temp = (*cur).DataInt;
            _D("argument : %d", temp);
            dbus_message_iter_append_basic(&args, DBUS_TYPE_INT32, &temp);
        }        
        else if((*cur).Type == TypeBool)
        {
            bool temp = (*cur).DataBool;
            dbus_bool_t value = false;
            if(temp == true)
            {
                value = true;
            }else
            {
                value = false;
            }
            _D("argument : %s", temp==true?"true":"false");
            dbus_message_iter_append_basic(&args, DBUS_TYPE_BOOLEAN, &value);
        }
    }
    Arguments.clear();

    DBusError err;
    dbus_error_init(&err);
    DBusMessage* reply = dbus_connection_send_with_reply_and_block(DbusConnection, msg, DBUS_REPLY_TIMEOUT, &err);
    dbus_message_unref(msg);

    if (!reply) 
    {
        _E("dbus_connection_send_with_reply_and_block error %s: %s", err.name, err.message);
        dbus_error_free(&err);
        return 0;
    }
    return reply;
}

vector<SignalHandler> DBusSignal::SignalVector;

DBusSignal::DBusSignal() : EdbusConnection(NULL), EdbusHandler(NULL)  
{
}

DBusSignal::~DBusSignal() 
{
    if (EdbusHandler != NULL) 
    {
        e_dbus_signal_handler_del(EdbusConnection, EdbusHandler);
        EdbusHandler = NULL;
    }

    if (EdbusConnection != NULL)
     {
        e_dbus_connection_close(EdbusConnection);
        EdbusConnection = NULL;
    }
}

DBusSignal* DBusSignal::getInstance() 
{
  static DBusSignal instance;
  return &instance;
}

int DBusSignal::InitConnection()
{
    _D("Enter");
    e_dbus_init();
    EdbusConnection = e_dbus_bus_get(DBUS_BUS_SYSTEM);
    if (EdbusConnection == NULL) 
    {
        _E("noti register : failed to get dbus bus");
        return -1;
    }

    string method = "Event";    
    EdbusHandler = e_dbus_signal_handler_add(EdbusConnection, NULL, 
                     ObjectPath.c_str(), InterfaceName.c_str(), method.c_str(), DBusSignalHandler, 0);
    if (EdbusHandler == NULL)
    {
        _E("fail to add size signal");
        return -1;
    }
    return 0;
}

void DBusSignal::DBusSignalHandler(void *data, DBusMessage *msg)
{
    _D("Enter");
    if (NULL == msg) 
    {
        _E("Message Null");
        return;
    }

    for (auto iter : SignalVector)
    {
        iter(NULL, msg);
    }
    return;
}

int DBusSignal::RegisterSignal(SignalHandler callback) 
{
    _D("Enter");
    if(nullptr == EdbusConnection)
    {
        InitConnection();
    
    }
    SignalHandler _handler = std::move(callback);
    SignalVector.push_back(_handler);
    return 0;
}