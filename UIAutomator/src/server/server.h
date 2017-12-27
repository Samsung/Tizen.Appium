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

#ifndef __SERVER_H_
#define __SERVER_H_

#include <string>
#include <vector>
#include <memory>
#include <mutex>
#include <map>
#include <condition_variable>

#include "common/dbus_utils.h"
#include "request.h"

using namespace std;

class Server
{
public:
    Server();
    ~Server();
    void exit();
    void init();

    static Server& getInstance();

    string GetAutomationId(char* data);
    string GetCommand(char* data);
    string GetAction(char* data);
    string GetElementId(char* data);
    string FindReply(string elementId);
    string ActionReply(bool result);
    string ActionReply(string value);
    int GetX(char* data);
    int GetY(char* data);
    int GetRequestId();
    void SignalHandler(DBusMessage* msg);

    void AddRequest(Request req);
    void UpdateAction(int requestId, string action);
    Request GetRequest(int requestId);
    void SetPosition(int requestId, int X, int Y);
    void SetAppSocket(int socket);
    int GetAppSocket();
    int WriteToApp(char* buf);
    char* ReadFromApp();
private:
    map<int, Request> RequestMap;
    int RequestCnt;
    int AppSocket;
};

#endif /* __SERVER_H_ */