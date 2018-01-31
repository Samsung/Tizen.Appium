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
#include <functional>
#include <condition_variable>
#include <Ecore_Con.h>

#include "common/dbus_utils.h"
#include "request.h"
#include "inputgenerator/touch.h"
#include "inputgenerator/keyboard.h"

using namespace std;

typedef std::function<void(char* buf)> CommandHandler;

class Server
{
public:
    Server();
    ~Server();
    void exit();
    void init();

    static Server& getInstance();

    string GetRequestId();
    void AddRequest(Request req);
    Request GetRequest(string requestId);
    void UpdateAction(string requestId, string action);
    void SetPosition(string requestId, int X, int Y);
    void SetAppSocket(Ecore_Con_Client* socket);
    void SendMessageToAppium(string msg);
    
    string ElementGetProperty(string automationId, string property);
    string ElementGetStringMessage(string automationId, string method);
    int ElementGetIntMessage(string automationId, string method);
    bool ElementSubscriveEvent(string automationId, string eventName, string requestId, bool once);

    void AddHandler(string action, CommandHandler function);
    void EventHandler(void *data, DBusMessage *msg);
    void ShutDownHandler();
    void ClickHandler(char* buf);
    void FindHandler(char* buf);
    void InputTextHandler(char* buf);
    void FlickHandler(char* buf);
    void GetAttributeHandler(char* buf);
    void GetSizeHandler(char* buf);
    void TouchDownHandler(char* buf);
    void TouchUpHandler(char* buf);
    void TouchMoveHandler(char* buf);
    void GetLocationHandler(char* buf);
    std::map<string, CommandHandler> HandlerMap;
private:
    map<string, Request> RequestMap;
    int RequestCnt;
    Ecore_Con_Client* Appium;
    Touch touch;
    Keyboard keyboard;
};

#endif /* __SERVER_H_ */
