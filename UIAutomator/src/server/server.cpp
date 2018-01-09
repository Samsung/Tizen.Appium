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

#include "server.h"
#include "common/log.h"
#include "common/common.h"
#include "common/dbus_utils.h"
#include "common/type.h"
#include "input_generator.h"
#include "json_utils.h"
#include "request.h"

#include <chrono>
#include <thread>
#include <sys/types.h>
#include <sys/socket.h>
#include <sys/stat.h>
#include <unistd.h>
#include <fcntl.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <pthread.h>
#include <json/json.h>
#include <glib.h>
#include <gio/gio.h>
#include <Ecore.h>
#include <Ecore_Con.h>

using namespace std;

const int SERVER_TIMEOUT = 300;

Server::Server()
{
    _D("Enter");
    RequestCnt = 1;
}

void Server::AddHandler(string action, CommandHandler function)
{
    HandlerMap[action] = std::move(function);
}

Server::~Server()
{
    _D("Enter");
}

Server& Server::getInstance()
{
    static Server instance;
    return instance;
}

void Server::AddRequest(Request req)
{
    if(req.RequestId != -1)
    {
        RequestMap[req.RequestId] = req;
    }
}

Request Server::GetRequest(int requestId)
{
    if(requestId != -1)
    {
        return RequestMap[requestId];
    }
    Request req;
    return req;
}

void Server::UpdateAction(int requestId, string action)
{
    if(requestId != -1)
    {
        RequestMap[requestId].Command = action;
    }
}

void Server::SetPosition(int requestId, int X, int Y)
{
    if(requestId != -1)
    {
        RequestMap[requestId].X = X;
        RequestMap[requestId].Y = Y;
    }
}

int Server::GetRequestId()
{
    return RequestCnt++;
}

int Server::GetX(char* data)
{
    string split = "/";
    string origin = data;
    int idx = origin.find(split);
    char temp[5];
    for(int i =0 ; i<idx ; i++)
    {
        temp[i] = data[i];
    }
    temp[idx] = '\0';
    int X = atoi(temp);
    return X;
}

int Server::GetY(char* data)
{
    string split = "/";
    string origin = data;
    int idx = origin.find(split);
    char temp[5];
    int i=0;
    for( ; i+idx+1 < (int)strlen(data) ; i++ )
    {
        temp[i] = data[i+idx+1];
    }
    temp[i] = '\0';
    int Y = atoi(temp);
    return Y;
}

void Server::SetAppSocket(Ecore_Con_Client* socket)
{
    Appium = socket;
}

Eina_Bool ClientAddCallback(void *data EINA_UNUSED, int type EINA_UNUSED, Ecore_Con_Event_Client_Add *ev)
{
   _D("Connected with Appium");
   Server::getInstance().SetAppSocket(ev->client);
   return ECORE_CALLBACK_RENEW;
}

Eina_Bool ClientDeleteCallback(void *data EINA_UNUSED, int type EINA_UNUSED, Ecore_Con_Event_Client_Del *ev)
{
   _D("Disconnected with Appium");
   if (ev->client)
   {
       ecore_con_client_del(ev->client);
   }
   return ECORE_CALLBACK_RENEW;
}

Eina_Bool ClientDataCallback(void *data EINA_UNUSED, int type EINA_UNUSED, Ecore_Con_Event_Client_Data *ev)
{
    char buf[255];
    memset(buf, 0, 255);
    sprintf(buf, "%s", (char*)ev->data);
    _D("Received :%s", buf);

    string cmd = JsonUtils::GetCommand(buf);
    if(!cmd.compare(COMMAND_SHUTDOWN))
    {
        Server::getInstance().ShutDownHandler();
        return ECORE_CALLBACK_RENEW;
    }

    string action = JsonUtils::GetAction(buf);
    if(Server::getInstance().HandlerMap.find(action) != Server::getInstance().HandlerMap.end())
    {
        _D("Find [%s] Handler", action.c_str());
        Server::getInstance().HandlerMap[action](buf);
    }
    else
    {
        _D("Invalid Command");
    }
    return ECORE_CALLBACK_RENEW;
}

void Server::FindHandler(char* buf)
{
    _D("Enter");
    Request request;
    request.RequestId = Server::getInstance().GetRequestId();
    request.AutomationId = JsonUtils::GetParam(buf, "selector");
    string action = JsonUtils::GetAction(buf);
    request.Command = action;

    char* args = strdup(request.AutomationId.c_str());
    char* data = DBusMessage::getInstance()->SendSyncMessage(
                              ObjectPath, InterfaceName, GetPositionMethod, args);

    _D("%s", data);             
    request.X = Server::getInstance().GetX(data);
    request.Y = Server::getInstance().GetY(data);
    Server::getInstance().AddRequest(request);  

    string reply = JsonUtils::FindReply(to_string(request.RequestId));
    ecore_con_client_send(Appium, reply.c_str(), strlen(reply.c_str()));
    ecore_con_client_flush(Appium);
}

void Server::ClickHandler(char* buf)
{
    _D("Enter");
    string action = JsonUtils::GetAction(buf);
    string reqId = JsonUtils::GetParam(buf, "elementId");
    Server::getInstance().UpdateAction(atoi(reqId.c_str()), action);
    Request request = Server::getInstance().GetRequest(atoi(reqId.c_str()));
                    
    sprintf(buf,"%s/%s/%s", reqId.c_str(), request.AutomationId.c_str(), request.Command.c_str());
    char* args = strdup(buf);
    char* data = DBusMessage::getInstance()->SendSyncMessage(ObjectPath, InterfaceName, SetCommandMethod, args);
    _D("%s", data);
                    
    InputGenerator::getInstance().SendUinputEventForTouchMouse(DEVICE_TOUCH, request.X, request.Y);
}

void Server::PressKeycodeHandler(char* buf)
{
    _D("Enter");

}

void Server::FlickHandler(char* buf)
{
    _D("Enter");

}

void Server::GetAttributeHandler(char* buf)
{
    _D("Enter");

}


void Server::GetSizeHandler(char* buf)
{
    _D("Enter");

}

void Server::TouchDownHandler(char* buf)
{
    _D("Enter");

}

void Server::TouchUpHandler(char* buf)
{
    _D("Enter");

}

void Server::TouchMoveHandler(char* buf)
{
    _D("Enter");

}

void Server::GetLocationHandler(char* buf)
{
    _D("Enter");

}

void Server::ShutDownHandler()
{
   _D("Enter");
   string reply = JsonUtils::ActionReply("Shutdown");
   ecore_con_client_send(Appium, reply.c_str(), strlen(reply.c_str()));
   ecore_con_client_flush(Appium);
}

void Server::SignalHandler(DBusMessage* msg)
{
    _D("Enter");
    DBusMessageIter args;
    char* data = NULL;

    if (dbus_message_iter_init(msg, &args)){
        if(DBUS_TYPE_STRING == dbus_message_iter_get_arg_type(&args)) {
            dbus_message_iter_get_basic(&args, &data);

            char* requestId = strtok(data, "/");
            char* autoId = strtok(NULL, "/");
            char* command = strtok(NULL, "/");

            _D("%s %s %s", requestId, autoId, command);

            string reply = JsonUtils::ActionReply(true);
            ecore_con_client_send(Appium, reply.c_str(), strlen(reply.c_str()));
            ecore_con_client_flush(Appium);
        }
        dbus_message_iter_next(&args);
    }
    return;
}

void Server::init()
{
    _D("Init");

    DBusSignal::getInstance()->RegisterSignal(InterfaceName, CompleteSignal,
                                std::bind(&Server::SignalHandler, this, std::placeholders::_1));

    Server::getInstance().AddHandler(ACTION_FIND, std::bind(&Server::FindHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_FLICK, std::bind(&Server::FlickHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_CLICK, std::bind(&Server::ClickHandler, this, std::placeholders::_1));    
    Server::getInstance().AddHandler(ACTION_GET_SIZE, std::bind(&Server::GetSizeHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_TOUCH_DOWN, std::bind(&Server::TouchDownHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_TOUCH_UP, std::bind(&Server::TouchUpHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_TOUCH_MOVE, std::bind(&Server::TouchMoveHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_GET_LOCATION, std::bind(&Server::GetLocationHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_GET_ATTRIBUTE, std::bind(&Server::GetAttributeHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_PRESS_KEYCODE, std::bind(&Server::PressKeycodeHandler, this, std::placeholders::_1));
    
    Ecore_Con_Server *Server;
    if (!(Server = ecore_con_server_add(ECORE_CON_REMOTE_TCP, "127.0.0.1", 8888, NULL)))
    {
        _E("Fail to add server");
        return;
    }

   ecore_event_handler_add(ECORE_CON_EVENT_CLIENT_ADD, (Ecore_Event_Handler_Cb)ClientAddCallback, NULL);
   ecore_event_handler_add(ECORE_CON_EVENT_CLIENT_DEL, (Ecore_Event_Handler_Cb)ClientDeleteCallback, NULL);
   ecore_event_handler_add(ECORE_CON_EVENT_CLIENT_DATA, (Ecore_Event_Handler_Cb)ClientDataCallback, NULL);

   ecore_con_server_timeout_set(Server, SERVER_TIMEOUT);
   ecore_con_server_client_limit_set(Server, 3, 0);
}

void Server::exit()
{
    _D("End");
}