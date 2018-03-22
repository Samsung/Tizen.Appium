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
#include <Elementary.h>

#include "utils/dbus_utils.h"
#include "utils/log.h"
#include "utils/type.h"
#include "input_generator/input_generator.h"
#include "utils/json_utils.h"
#include "request.h"


using namespace std;

const int SERVER_TIMEOUT = 30000;
const double SUBSCRIBE_TIMEOUT = 5;


Server::Server()
{
    _D("Enter");
    RequestCnt = 1;
    SubscribeTimer = 0;
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

void Server::AddRequest(Request request)
{
    RequestMap[request.RequestId] = request;
}

Request Server::GetRequest(string requestId)
{
    if(RequestMap.find(requestId) != RequestMap.end())
    {
        return RequestMap[requestId];
    }
    else
    {
        _E("%s request is not found", requestId.c_str());
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

Request Server::GetRequestAfterUpdateAction(char* buf) {
    string action = JsonUtils::GetAction(buf);
    string requestId = JsonUtils::GetStringParam(buf, "elementId");

    UpdateAction(requestId, action);
    Request request = GetRequest(requestId);
    return request;
}

void Server::SetPosition(string requestId, int X, int Y)
{
    _D("Need to implement");
}

string Server::GetRequestId()
{
    return to_string(RequestCnt++);
}

void Server::SetAppSocket(Ecore_Con_Client* socket)
{
    Appium = socket;
}

Eina_Bool SubscribeTimeout(void* data)
{
    _D("Subscribe Timeout");
    Server::getInstance().DeleteTimer();
    string reply = JsonUtils::ActionReply(false);
    Server::getInstance().SendMessageToAppium(reply);
    return EINA_FALSE;
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
    _D("[%s]", buf);

    string cmd = JsonUtils::GetCommand(buf);
    if(!cmd.compare(COMMAND_SHUTDOWN))
    {
        Server::getInstance().ShutDownHandler();
        return ECORE_CALLBACK_RENEW;
    }

    string action = JsonUtils::GetAction(buf);
    if(Server::getInstance().HandlerMap.find(action) != Server::getInstance().HandlerMap.end())
    {
        _D("[%s] Handler", action.c_str());
        Server::getInstance().HandlerMap[action](buf);
    }
    else
    {
        _D("Invalid Command");
        string reply = JsonUtils::ActionReply(false);
        Server::getInstance().SendMessageToAppium(reply);
    }
    return ECORE_CALLBACK_RENEW;
}

void Server::SendMessageToAppium(string msg)
{
    _D("Enter : %s", msg.c_str());
    ecore_con_client_send(Appium, msg.c_str(), strlen(msg.c_str()));
    ecore_con_client_flush(Appium);
}

string Server::ElementGetProperty(string automationId, string property)
{
    _D("Get %s of %s", property.c_str(), automationId.c_str());
    DBusMessage::getInstance()->AddArgument(automationId);
    DBusMessage::getInstance()->AddArgument(property);
    DBusMessage* reply = DBusMessage::getInstance()->SendSyncMessage("GetProperty");
    char* result = nullptr;
    DBusMessage::getInstance()->GetReplyMessage(reply, &result);
    string ret = (result != nullptr)? result : "";
    return ret;
}

bool Server::ElementSetProperty(string automationId, string property, string value)
{
    _D("Set %s of %s to %s", property.c_str(), automationId.c_str(), value.c_str());
    DBusMessage::getInstance()->AddArgument(automationId);
    DBusMessage::getInstance()->AddArgument(property);
    DBusMessage::getInstance()->AddArgument(value);
    DBusMessage* reply = DBusMessage::getInstance()->SendSyncMessage("SetProperty");
    bool ret = false;
    DBusMessage::getInstance()->GetReplyMessage(reply, &ret);
    return ret;
}

int Server::ElementGetIntMessage(string automationId, string method)
{
    _D("%s of %s", method.c_str(), automationId.c_str());
    DBusMessage::getInstance()->AddArgument(automationId);
    DBusMessage* reply = DBusMessage::getInstance()->SendSyncMessage(method);
    int ret;
    DBusMessage::getInstance()->GetReplyMessage(reply, &ret);
    return ret;
}

string Server::ElementGetStringMessage(string automationId, string method)
{
    _D("%s of %s", method.c_str(), automationId.c_str());
    DBusMessage::getInstance()->AddArgument(automationId);
    DBusMessage* reply = DBusMessage::getInstance()->SendSyncMessage(method);
    char* ret = nullptr;
    DBusMessage::getInstance()->GetReplyMessage(reply, &ret);
    string result = (ret != nullptr) ? ret : "";
    return result;
}

void Server::FindHandler(char* buf)
{
    _D("Enter");
    Request request;
    request.RequestId = GetRequestId();
    request.AutomationId = JsonUtils::GetStringParam(buf, "selector");
    request.Command = JsonUtils::GetAction(buf);;

    AddRequest(request);

    string replyMsg = JsonUtils::FindReply(request.RequestId);
    SendMessageToAppium(replyMsg);
}

bool Server::ElementSubscriveEvent(string automationId, string eventName, string requestId, bool once)
{
    _D("Subscribe : automationId=%s, eventName=%s requestId=%s once=%d",
        automationId.c_str(), eventName.c_str(), requestId.c_str(), once);
    DBusMessage::getInstance()->AddArgument(automationId);
    DBusMessage::getInstance()->AddArgument(eventName);
    DBusMessage::getInstance()->AddArgument(requestId);
    DBusMessage::getInstance()->AddArgument(once);

    DBusMessage* reply = DBusMessage::getInstance()->SendSyncMessage("SubscribeEvent");
    bool ret = false;
    DBusMessage::getInstance()->GetReplyMessage(reply, &ret);
    return ret;
}

void Server::InputTextHandler(char* buf)
{
    _D("Enter");
    string text = JsonUtils::GetStringParam(buf, "text");
    int count = text.size();
    char codes[count + 1];
    strcpy(codes, text.c_str());
    codes[sizeof(codes) - 1] = 0;
    for (int i = 0; i < count; i++)
    {
        keyboard.PressKeyCode(codes[i]);
    }
    string reply = JsonUtils::ActionReply(true);
    SendMessageToAppium(reply);
}

void Server::ClickHandler(char* buf)
{
    string requestId = JsonUtils::GetStringParam(buf, "elementId");
    Request request = GetRequest(requestId);
    _D("RequestId : %s", request.RequestId.c_str());

    if (request.RequestId.empty())
    {
        int X = JsonUtils::GetIntParam(buf, "x");
        int Y = JsonUtils::GetIntParam(buf, "y");

        touch.Click(X, Y);

        string reply = JsonUtils::ActionReply(true);
        SendMessageToAppium(reply);
    }
    else
    {
        string action = JsonUtils::GetAction(buf);
        UpdateAction(request.RequestId, action);

        bool result = ElementSubscriveEvent(request.AutomationId, "MouseUp", request.RequestId, true);
        if (result == true)
        {
            int X = ElementGetIntMessage(request.AutomationId, "GetCenterX");
            int Y = ElementGetIntMessage(request.AutomationId, "GetCenterY");
            touch.Click(X, Y);

            SubscribeTimer = ecore_timer_loop_add(SUBSCRIBE_TIMEOUT, SubscribeTimeout, 0);
        }
        else
        {
            _E("Fail to subscribe event");
            string reply = JsonUtils::ActionReply(false);
            SendMessageToAppium(reply);
        }
    }
}

void Server::TouchDownHandler(char* buf)
{
    string requestId = JsonUtils::GetStringParam(buf, "elementId");
    Request request = GetRequest(requestId);

    if (request.RequestId.empty())
    {
        int X = JsonUtils::GetIntParam(buf, "x");
        int Y = JsonUtils::GetIntParam(buf, "y");

        touch.Down(X, Y);

        string reply = JsonUtils::ActionReply(true);
        SendMessageToAppium(reply);
    }
    else
    {
        string action = JsonUtils::GetAction(buf);
        UpdateAction(request.RequestId, action);

        bool result = ElementSubscriveEvent(request.AutomationId, "MouseDown", request.RequestId, true);
        if (result == true)
        {
            int X = ElementGetIntMessage(request.AutomationId, "GetCenterX");
            int Y = ElementGetIntMessage(request.AutomationId, "GetCenterY");
            touch.Down(X, Y);

            SubscribeTimer = ecore_timer_loop_add(SUBSCRIBE_TIMEOUT, SubscribeTimeout, 0);
        }
        else
        {
            _E("Fail to subscribe event");
            string reply = JsonUtils::ActionReply(false);
            SendMessageToAppium(reply);
        }
    }
}

void Server::TouchUpHandler(char* buf)
{
    string requestId = JsonUtils::GetStringParam(buf, "elementId");
    Request request = GetRequest(requestId);

    if (request.RequestId.empty())
    {
        int X = JsonUtils::GetIntParam(buf, "x");
        int Y = JsonUtils::GetIntParam(buf, "y");

        touch.Up(X, Y);

        string reply = JsonUtils::ActionReply(true);
        SendMessageToAppium(reply);
    }
    else
    {
        string action = JsonUtils::GetAction(buf);
        UpdateAction(request.RequestId, action);

        bool result = ElementSubscriveEvent(request.AutomationId, "MouseUp", request.RequestId, true);
        if (result == true)
        {
            int X = ElementGetIntMessage(request.AutomationId, "GetCenterX");
            int Y = ElementGetIntMessage(request.AutomationId, "GetCenterY");
            touch.Up(X, Y);

            SubscribeTimer = ecore_timer_loop_add(SUBSCRIBE_TIMEOUT, SubscribeTimeout, 0);
        }
        else
        {
            _E("Fail to subscribe event");
            string reply = JsonUtils::ActionReply(false);
            SendMessageToAppium(reply);
        }
    }
}

void Server::TouchMoveHandler(char* buf)
{
    string requestId = JsonUtils::GetStringParam(buf, "elementId");
    Request request = GetRequest(requestId);

    if (request.RequestId.empty())
    {
        int X = JsonUtils::GetIntParam(buf, "x");
        int Y = JsonUtils::GetIntParam(buf, "y");

        touch.Move(X, Y);

        string reply = JsonUtils::ActionReply(true);
        SendMessageToAppium(reply);
    }
    else
    {
        string action = JsonUtils::GetAction(buf);
        UpdateAction(request.RequestId, action);

        bool result = ElementSubscriveEvent(request.AutomationId, "MouseMove", request.RequestId, true);
        if (result == true)
        {
            int X = ElementGetIntMessage(request.AutomationId, "GetCenterX");
            int Y = ElementGetIntMessage(request.AutomationId, "GetCenterY");
            touch.Move(X, Y);

            SubscribeTimer = ecore_timer_loop_add(SUBSCRIBE_TIMEOUT, SubscribeTimeout, 0);
        }
        else
        {
            _E("Fail to subscribe event");
            string reply = JsonUtils::ActionReply(false);
            SendMessageToAppium(reply);
        }
    }
}

void Server::TouchLongClickHandler(char* buf) {
    string requestId = JsonUtils::GetStringParam(buf, "elementId");
    Request request = GetRequest(requestId);
    int duration = JsonUtils::GetIntParam(buf, "duration");

    _D("duration : %d", duration);

    if (duration == -1) {
        duration = 2000;
    }

    if (request.RequestId.empty())
    {
        int X = JsonUtils::GetIntParam(buf, "x");
        int Y = JsonUtils::GetIntParam(buf, "y");

        touch.Down(X, Y);
        usleep(duration);
        touch.Up(X, Y);

        string reply = JsonUtils::ActionReply(true);
        SendMessageToAppium(reply);
    }
    else
    {
        string action = JsonUtils::GetAction(buf);
        UpdateAction(request.RequestId, action);

        bool result = ElementSubscriveEvent(request.AutomationId, "MouseUp", request.RequestId, true);
        if (result == true)
        {
            int X = ElementGetIntMessage(request.AutomationId, "GetCenterX");
            int Y = ElementGetIntMessage(request.AutomationId, "GetCenterY");
            touch.Down(X, Y);
            usleep(duration);
            touch.Up(X, Y);
        }
        else
        {
            _E("Fail to subscribe event");
            string reply = JsonUtils::ActionReply(false);
            SendMessageToAppium(reply);
        }
    }
}

void Server::FlickHandler(char* buf)
{
    string requestId = JsonUtils::GetStringParam(buf, "elementId");
    Request request = GetRequest(requestId);

    if (request.RequestId.empty())
    {
        int xSpeed = JsonUtils::GetIntParam(buf, "xSpeed");
        int ySpeed = JsonUtils::GetIntParam(buf, "ySpeed");

        touch.Flick(xSpeed, ySpeed);

        string reply = JsonUtils::ActionReply(true);
        SendMessageToAppium(reply);
    }
    else
    {
        string action = JsonUtils::GetAction(buf);
        UpdateAction(request.RequestId, action);

        bool result = ElementSubscriveEvent(request.AutomationId, "MouseUp", request.RequestId, true);
        if (result == true)
        {
            int xoffset = JsonUtils::GetIntParam(buf, "xoffset");
            int yoffset = JsonUtils::GetIntParam(buf, "yoffset");
            int speed = JsonUtils::GetIntParam(buf, "speed");
            int steps = 1250.0 / speed + 1;

            int xStart = ElementGetIntMessage(request.AutomationId, "GetCenterX");
            int yStart = ElementGetIntMessage(request.AutomationId, "GetCenterY");
            int xEnd = xStart + xoffset;
            int yEnd = yStart + yoffset;

            touch.Swipe(xStart, yStart, xEnd, yEnd, steps);
        }
        else
        {
            _E("Fail to subscribe event");
            string reply = JsonUtils::ActionReply(false);
            SendMessageToAppium(reply);
        }
    }
}

void Server::GetAttributeHandler(char* buf)
{
    string attribute = JsonUtils::GetStringParam(buf, "attribute");
    _D("Attribute : [%s]", attribute.c_str());
    string elementId = JsonUtils::GetStringParam(buf, "elementId");
    Request request = GetRequest(elementId);
    string replyMsg;
    if(!attribute.compare(ATTRIBUTE_TEXT))
    {
        string result = ElementGetStringMessage(request.AutomationId, "GetText");
        replyMsg = JsonUtils::ActionReply(result);
    }
    else if(!attribute.compare(ATTRIBUTE_ENABLED))
    {
        string ret = ElementGetProperty(request.AutomationId, "IsEnabled");
        replyMsg = JsonUtils::ActionReply(ret);
    }
    else if(!attribute.compare(ATTRIBUTE_NAME))
    {
        replyMsg = JsonUtils::ActionReply(request.AutomationId);
    }
    else if(!attribute.compare(ATTRIBUTE_DISPLAYED))
    {
        string ret = ElementGetProperty(request.AutomationId, "IsVisible");
        replyMsg = JsonUtils::ActionReply(ret);
    }
    else if (!attribute.compare(ATTRIBUTE_SIZE))
    {
        Request request = GetRequest(elementId);

        string ret = ElementGetProperty(request.AutomationId, "Width");
        int width = atoi(ret.c_str());

        ret = ElementGetProperty(request.AutomationId, "Height");
        int height = atoi(ret.c_str());

        replyMsg = JsonUtils::ReplyAxis("width", width, "height", height);
    }
    else
    {
        string result = ElementGetProperty(request.AutomationId, attribute);
        replyMsg = JsonUtils::ActionReply(result);
    }

    Server::getInstance().SendMessageToAppium(replyMsg);
}

void Server::SetAttributeHandler(char* buf)
{
    string attribute = JsonUtils::GetStringParam(buf, "attribute");
    _D("Attribute : [%s]", attribute.c_str());
    string elementId = JsonUtils::GetStringParam(buf, "elementId");
    string value = JsonUtils::GetStringParam(buf, "value");
    Request request = GetRequest(elementId);

    string replyMsg;

    bool result = ElementSetProperty(request.AutomationId, attribute, value);
    replyMsg = JsonUtils::ActionReply(result);

    SendMessageToAppium(replyMsg);
}


void Server::GetSizeHandler(char* buf)
{
    _D("Enter");
    string elementId = JsonUtils::GetStringParam(buf, "elementId");
    Request request = GetRequest(elementId);

    string ret = ElementGetProperty(request.AutomationId, "Width");
    int width = atoi(ret.c_str());

    ret = ElementGetProperty(request.AutomationId, "Height");
    int height = atoi(ret.c_str());

    string result = JsonUtils::ReplyAxis("width", width, "height", height);
    SendMessageToAppium(result);
}

void Server::GetLocationHandler(char* buf)
{
    _D("Enter");
    string elementId = JsonUtils::GetStringParam(buf, "elementId");
    Request request = GetRequest(elementId);

    int X = ElementGetIntMessage(request.AutomationId, "GetCenterX");
    int Y = ElementGetIntMessage(request.AutomationId, "GetCenterY");

    string result = JsonUtils::ReplyAxis("x", X, "y", Y);
    SendMessageToAppium(result);
}

void Server::PressHardWareKeyHandler(char* buf)
{
    string keyCode = JsonUtils::GetStringParam(buf, "keyCode");
    hardwareKey.PressKeyCode(keyCode);

    string reply = JsonUtils::ActionReply(true);
    SendMessageToAppium(reply);
}

void Server::ShutDownHandler()
{
    _D("Enter");
    string reply = JsonUtils::ActionReply("Shutdown");
    SendMessageToAppium(reply);
}

void Server::EventHandler(void *data, DBusMessage *msg)
{
    _D("Enter");
    DeleteTimer();

    DBusMessageIter args;
    char* elementId = NULL;
    char* eventName = NULL;
    char* reuqestId = NULL;
    if (dbus_message_iter_init(msg, &args))
    {
        dbus_message_iter_get_basic(&args, &elementId);
        dbus_message_iter_next(&args);
        dbus_message_iter_get_basic(&args, &eventName);
        dbus_message_iter_next(&args);
        dbus_message_iter_get_basic(&args, &reuqestId);
        dbus_message_iter_next(&args);
        _D("ElementId=%s, EventName=%s, ReuqestId=%s", elementId, eventName, reuqestId);
    }
    string reply = JsonUtils::ActionReply(true);
    SendMessageToAppium(reply);
    return;
}

void Server::DeleteTimer()
{
    if(SubscribeTimer != 0){
        ecore_timer_del(SubscribeTimer);
        SubscribeTimer = 0;
        _D("Timer deleted");
    }
}

void Server::init()
{
    _D("Server init");
    DBusSignal::getInstance()->RegisterSignal(std::bind(&Server::EventHandler, this, std::placeholders::_1, std::placeholders::_2));

    AddHandler(ACTION_FIND, std::bind(&Server::FindHandler, this, std::placeholders::_1));
    AddHandler(ACTION_CLICK, std::bind(&Server::ClickHandler, this, std::placeholders::_1));
    AddHandler(ACTION_TOUCH_DOWN, std::bind(&Server::TouchDownHandler, this, std::placeholders::_1));
    AddHandler(ACTION_TOUCH_UP, std::bind(&Server::TouchUpHandler, this, std::placeholders::_1));
    AddHandler(ACTION_TOUCH_MOVE, std::bind(&Server::TouchMoveHandler, this, std::placeholders::_1));
    AddHandler(ACTION_TOUCH_LONG_CLICK, std::bind(&Server::TouchLongClickHandler, this, std::placeholders::_1));
    AddHandler(ACTION_FLICK, std::bind(&Server::FlickHandler, this, std::placeholders::_1));
    AddHandler(ACTION_GET_SIZE, std::bind(&Server::GetSizeHandler, this, std::placeholders::_1));
    AddHandler(ACTION_GET_LOCATION, std::bind(&Server::GetLocationHandler, this, std::placeholders::_1));
    AddHandler(ACTION_GET_ATTRIBUTE, std::bind(&Server::GetAttributeHandler, this, std::placeholders::_1));
    AddHandler(ACTION_SET_ATTRIBUTE, std::bind(&Server::SetAttributeHandler, this, std::placeholders::_1));
    AddHandler(ACTION_INPUT_TEXT, std::bind(&Server::InputTextHandler, this, std::placeholders::_1));
    AddHandler(ACTION_PRESS_HARDWARE_KEY, std::bind(&Server::PressHardWareKeyHandler, this, std::placeholders::_1));

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
