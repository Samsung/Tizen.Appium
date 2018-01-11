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

const int SERVER_TIMEOUT = 3000;

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
    RequestMap[req.RequestId] = req;
}

Request Server::GetRequest(string requestId)
{
    if(RequestMap.find(requestId) != RequestMap.end())
    {
        return RequestMap[requestId];
    }
    Request req;
    return req;
}

void Server::UpdateAction(string requestId, string action)
{
    if(RequestMap.find(requestId) != RequestMap.end())
    {
        RequestMap[requestId].Command = action;
    }
}

void Server::SetPosition(string requestId, int X, int Y)
{
    if(RequestMap.find(requestId) != RequestMap.end())
    {
        RequestMap[requestId].X = X;
        RequestMap[requestId].Y = Y;
    }
}

string Server::GetRequestId()
{
    return to_string(RequestCnt++);
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
    request.AutomationId = JsonUtils::GetStringParam(buf, "selector");
    request.Command = JsonUtils::GetAction(buf);;

    DBusMessage::getInstance()->AddArgument(request.AutomationId);
    DBusMessage* reply = DBusMessage::getInstance()->SendSyncMessage("GetCenterX");
    DBusMessage::getInstance()->GetReplyMessage(reply, &(request.X));

    DBusMessage::getInstance()->AddArgument(request.AutomationId);
    reply = DBusMessage::getInstance()->SendSyncMessage("GetCenterY");
    DBusMessage::getInstance()->GetReplyMessage(reply, &(request.Y));
    
    _D("X: %d ,  Y : %d from app", request.X, request.Y);             
    Server::getInstance().AddRequest(request);  

    string result = JsonUtils::FindReply(request.RequestId);
    ecore_con_client_send(Appium, result.c_str(), strlen(result.c_str()));
    ecore_con_client_flush(Appium);
}

void Server::ClickHandler(char* buf)
{
    _D("Enter");
    string action = JsonUtils::GetAction(buf);
    string requestId = JsonUtils::GetStringParam(buf, "elementId");

    Server::getInstance().UpdateAction(requestId, action);
    Request request = Server::getInstance().GetRequest(requestId);

    DBusMessage::getInstance()->AddArgument(request.AutomationId);
    DBusMessage::getInstance()->AddArgument("MouseDown");
    DBusMessage::getInstance()->AddArgument(request.RequestId);
    DBusMessage::getInstance()->AddArgument(true);

    DBusMessage* reply = DBusMessage::getInstance()->SendSyncMessage("SubscribeEvent");
    bool result = false;
    DBusMessage::getInstance()->GetReplyMessage(reply, &result);
    _D("%s from app", result?"true":"false");
    
    if(result == true)
    {
        InputGenerator::getInstance().SendUinputEventForTouchMouse(DEVICE_TOUCH, request.X, request.Y);
    }
    else 
    {
        _E("Fail to subscribe event");
        string reply = JsonUtils::ActionReply(false);
        ecore_con_client_send(Appium, reply.c_str(), strlen(reply.c_str()));
        ecore_con_client_flush(Appium);
    }                
}

void Server::InputTextHandler(char* buf)
{
    _D("Enter");
    string keycode = JsonUtils::GetStringParam(buf, "keycode");
    // To do : call press keycode mehtod of input generator
}

void Server::FlickHandler(char* buf)
{
    _D("Enter");
    string action = JsonUtils::GetAction(buf);
    int xSpeed = JsonUtils::GetIntParam(buf, "xSpeed");
    int ySpeed = JsonUtils::GetIntParam(buf, "ySpeed");
    _D("xSpeed : %d, ySpeed : %d", xSpeed, ySpeed);
    InputGenerator::getInstance().SendUinputEventForFlick(DEVICE_TOUCH, xSpeed, ySpeed);
}

void Server::GetAttributeHandler(char* buf)
{
    _D("Enter");
    string attribute = JsonUtils::GetStringParam(buf, "attribute");
    string elementId = JsonUtils::GetStringParam(buf, "elementId");
    Request request = Server::getInstance().GetRequest(elementId);
    if(!attribute.compare(ATTRIBUTE_TEXT))
    {
        DBusMessage::getInstance()->AddArgument(request.AutomationId);
        DBusMessage* reply = DBusMessage::getInstance()->SendSyncMessage("GetText");
        char* replyResult = 0;
        DBusMessage::getInstance()->GetReplyMessage(reply, &replyResult);
        _D("GetText : [%s]", replyResult);

        string elementText = replyResult;
        string result = JsonUtils::ActionReply(elementText);
        ecore_con_client_send(Appium, result.c_str(), strlen(result.c_str()));
        ecore_con_client_flush(Appium);
    }
    else if(!attribute.compare(ATTRIBUTE_ENABLED))
    {
        DBusMessage::getInstance()->AddArgument(request.AutomationId);
        DBusMessage::getInstance()->AddArgument("IsEnabled");
        DBusMessage* reply = DBusMessage::getInstance()->SendSyncMessage("GetProperty");
        char* replyResult = 0;
        DBusMessage::getInstance()->GetReplyMessage(reply, &replyResult);
        _D("Enabled : [%s]", replyResult);

        string elementText = replyResult;
        string result = JsonUtils::ActionReply(elementText);
        ecore_con_client_send(Appium, result.c_str(), strlen(result.c_str()));
        ecore_con_client_flush(Appium);
    }
    else if(!attribute.compare(ATTRIBUTE_NAME))
    {
        _D("Name : [%s]", request.AutomationId.c_str());
        string result = JsonUtils::ActionReply(request.AutomationId);
        ecore_con_client_send(Appium, result.c_str(), strlen(result.c_str()));
        ecore_con_client_flush(Appium);
    }
    else if(!attribute.compare(ATTRIBUTE_DISPLAYED))
    {
        // TO DO : discuss about displayed property 
        _D("Displayed :");
        string displayed = "true";
        string result = JsonUtils::ActionReply(displayed);
        ecore_con_client_send(Appium, result.c_str(), strlen(result.c_str()));
        ecore_con_client_flush(Appium);
    }
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

void Server::EventHandler(DBusMessage* msg)
{
    _D("Enter");
    DBusMessageIter args;
    char* data = NULL;

    if (dbus_message_iter_init(msg, &args))
    {
        if(DBUS_TYPE_STRING == dbus_message_iter_get_arg_type(&args)) 
        {
            dbus_message_iter_get_basic(&args, &data);
            _D("ElementId : %s", data);
        }
        dbus_message_iter_next(&args);
        if(DBUS_TYPE_STRING == dbus_message_iter_get_arg_type(&args)) 
        {
            dbus_message_iter_get_basic(&args, &data);
            _D("EventName : %s", data);
        }
        dbus_message_iter_next(&args);

        if(DBUS_TYPE_STRING == dbus_message_iter_get_arg_type(&args)) 
        {
            dbus_message_iter_get_basic(&args, &data);
            _D("ReuqestId : %s", data);
        }
        dbus_message_iter_next(&args);
    }
    string reply = JsonUtils::ActionReply(true);
    ecore_con_client_send(Appium, reply.c_str(), strlen(reply.c_str()));
    ecore_con_client_flush(Appium);
    return;
}

void Server::init()
{
    _D("Init 10.09");

    DBusSignal::getInstance()->RegisterSignal(InterfaceName, "Event",
                                std::bind(&Server::EventHandler, this, std::placeholders::_1));

    Server::getInstance().AddHandler(ACTION_FIND, std::bind(&Server::FindHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_FLICK, std::bind(&Server::FlickHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_CLICK, std::bind(&Server::ClickHandler, this, std::placeholders::_1));    
    Server::getInstance().AddHandler(ACTION_GET_SIZE, std::bind(&Server::GetSizeHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_TOUCH_DOWN, std::bind(&Server::TouchDownHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_TOUCH_UP, std::bind(&Server::TouchUpHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_TOUCH_MOVE, std::bind(&Server::TouchMoveHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_GET_LOCATION, std::bind(&Server::GetLocationHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_GET_ATTRIBUTE, std::bind(&Server::GetAttributeHandler, this, std::placeholders::_1));
    Server::getInstance().AddHandler(ACTION_INPUT_TEXT, std::bind(&Server::InputTextHandler, this, std::placeholders::_1));
    
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