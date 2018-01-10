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

#ifndef _DBUS_UTILS_H_
#define _DBUS_UTILS_H_

#include <string>
#include <vector>
#include <map>
#include <set>
#include <functional>
#include <dbus/dbus.h>
#include "type.h"

using namespace std;

typedef std::function<void(DBusMessage* msg)> signalHandler;

enum ArgumentType
{
    TypeBool,
    TypeInt,
    TypeString,
};

class DBusArgument
{
public:
    DBusArgument();
    virtual ~DBusArgument();
    ArgumentType Type;
    int DataInt;
    string DataString;
    int DataBool;
};

class DBusMessage 
{
public:
    DBusMessage();
    virtual ~DBusMessage();
    static DBusMessage* getInstance();

    void AddArgument(string data);
    void AddArgument(bool data);
    void AddArgument(int data);
    DBusMessage* SendSyncMessage(string method);
    void GetReplyMessage(DBusMessage* reply, char** value);

private:
    string DBusDestination;
    string DBusPath;
    string DBusInterface; 
    DBusConnection* connection_;

    static std::set<DBusMessage*> s_objects_;
    vector<DBusArgument> Arguments;

    void CheckConnection();
};

class DBusSignal
{
public:
    DBusSignal();
    virtual ~DBusSignal();
    static DBusSignal* getInstance();

    int RegisterSignal(const std::string& dInterface, const std::string& dMethod, signalHandler callback);
    static DBusHandlerResult DBusSignalHandler(DBusConnection* conn, DBusMessage* msg,void* user_data);
private:
    DBusConnection* connection_;

    static std::map<std::string, signalHandler> signalMap;
    int InitializeConnection();
};

#endif // _DBUS_UTILS_H_
