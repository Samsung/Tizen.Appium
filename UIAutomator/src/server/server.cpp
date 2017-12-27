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

Server::Server()
{
    _D("Enter");
    RequestCnt = 1;
    AppSocket = -1;
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
    if(req.RequestId != -1){
        RequestMap[req.RequestId] = req;
    }
}

Request Server::GetRequest(int requestId)
{
    if(requestId != -1){
        return RequestMap[requestId];
    }
    Request req;
    return req;
}

void Server::UpdateAction(int requestId, string action)
{
    if(requestId != -1){
        RequestMap[requestId].Command = action;
    }
}

void Server::SetPosition(int requestId, int X, int Y)
{
    if(requestId != -1){
        RequestMap[requestId].X = X;
        RequestMap[requestId].Y = Y;
    }
}

int Server::GetRequestId()
{
    return RequestCnt++;
}

string Server::GetElementId(char* data)
{
    string buf = data;
    Json::Value root;
    Json::Reader reader;
    
    bool ret = reader.parse(buf, root);
    string id = root["params"]["elementId"].asString();
    return id;
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
    for( ; i+idx+1 < strlen(data) ; i++ )
    {
        temp[i] = data[i+idx+1];
    }
    temp[i] = '\0';
    int Y = atoi(temp);
    return Y;
}

string Server::ActionReply(string value)
{
    Json::Value root;
    root["status"] = 0;
    root["value"] = value;
    Json::StyledWriter writer;
    std::string ret = writer.write(root);
    _D("%s", ret.c_str());

    return ret;
}

string Server::ActionReply(bool result)
{
    Json::Value root;
    root["status"] = 0;
    root["value"] = result;
    Json::StyledWriter writer;
    std::string ret = writer.write(root);
    _D("%s", ret.c_str());

    return ret;
}

string Server::FindReply(string elementId)
{
    Json::Value root;
    root["status"] = 0;
    Json::Value list;
    list["ELEMENT"] = elementId;
    root["value"] = list;
    Json::StyledWriter writer;
    std::string ret = writer.write(root);
    _D("%s", ret.c_str());

    return ret;
}

string Server::GetAutomationId(char* data)
{
    string buf = data;
    Json::Value root;
    Json::Reader reader;
    bool ret = reader.parse(buf, root);
    string selector = root["params"]["selector"].asString();    
    return selector;
}

string Server::GetCommand(char* data)
{
    string buf = data;
    Json::Value root;
    Json::Reader reader;
    
    bool ret = reader.parse(buf, root);
    string command = root.get("cmd","").asString();
    return command;
}

string Server::GetAction(char* data)
{
    string buf = data;
    Json::Value root;
    Json::Reader reader;
    
    bool ret = reader.parse(buf, root);
    string command = root.get("cmd","").asString();
    string action = root.get("action","").asString();
    string id = root["params"]["elementId"].asString();

    return action;
}

int Server::GetAppSocket()
{
    return AppSocket;
}

void Server::SetAppSocket(int socket)
{
    AppSocket = socket;
}

Eina_Bool ClientAddCallback(void *data EINA_UNUSED, int type EINA_UNUSED, Ecore_Con_Event_Client_Add *ev)
{
   _D("Client is added");
   return ECORE_CALLBACK_RENEW;
}

Eina_Bool ClientDeleteCallback(void *data EINA_UNUSED, int type EINA_UNUSED, Ecore_Con_Event_Client_Del *ev)
{
   _D("Client is deleted");
   if (ev->client)
   {
       ecore_con_client_del(ev->client);
   }
   return ECORE_CALLBACK_RENEW;
}

Ecore_Con_Client* _client;

Eina_Bool ClientDataCallback(void *data EINA_UNUSED, int type EINA_UNUSED, Ecore_Con_Event_Client_Data *ev)
{
   char buf[255];
   memset(buf, '\0', 255);
   sprintf(buf, "%s", ev->data);
   _D("Received :%s", buf);
   string reply;

   string cmd = Server::getInstance().GetCommand(buf);
   if(!cmd.compare(COMMAND_SHUTDOWN))
   {
        _D("Shutdown");
        reply = Server::getInstance().ActionReply("Shutdown");
        
        ecore_con_client_send(ev->client, reply.c_str(), strlen(reply.c_str()));
        ecore_con_client_flush(ev->client);

        return ECORE_CALLBACK_RENEW;
   }
   else if (!cmd.compare(COMMAND_ACTION))
   {
        string action = Server::getInstance().GetAction(buf);
        if(!action.compare(ACTION_FIND))
        {
            _D("Element Find");
            Request request;
            request.RequestId = Server::getInstance().GetRequestId();
            request.AutomationId = Server::getInstance().GetAutomationId(buf);
            request.Command = action;

            char* args = strdup(request.AutomationId.c_str());
            char* data = DBusMessage::getInstance()->SendSyncMessage(
                                                ObjectPath, InterfaceName, GetPositionMethod, args);

            _D("%s", data);
                                            
            request.X = Server::getInstance().GetX(data);
            request.Y = Server::getInstance().GetY(data);

            Server::getInstance().AddRequest(request);  

            reply = Server::getInstance().FindReply(to_string(request.RequestId));
            ecore_con_client_send(ev->client, reply.c_str(), strlen(reply.c_str()));
            ecore_con_client_flush(ev->client);
        }
        else if(!action.compare(ACTION_CLICK))
        {
            _D("Action : Click");

            string reqId = Server::getInstance().GetElementId(buf);
            Server::getInstance().UpdateAction(atoi(reqId.c_str()), action);
            Request request = Server::getInstance().GetRequest(atoi(reqId.c_str()));
                    
            sprintf(buf,"%s/%s/%s", reqId.c_str(), request.AutomationId.c_str(), request.Command.c_str());
            char* args = strdup(buf);
            char* data = DBusMessage::getInstance()->SendSyncMessage(
                                                ObjectPath, InterfaceName, SetCommandMethod, args);
            _D("%s", data);
                    
            InputGenerator::getInstance().SendUinputEventForTouchMouse(1, request.X, request.Y);

            _client = ev->client;
        }
   }
   return ECORE_CALLBACK_RENEW;
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

            string reply = Server::getInstance().ActionReply(true);
            ecore_con_client_send(_client, reply.c_str(), strlen(reply.c_str()));
            ecore_con_client_flush(_client);
        }
        dbus_message_iter_next(&args);
    }
    return;
}

void Server::init()
{
    _D("Enter");

    DBusSignal::getInstance()->RegisterSignal(InterfaceName, CompleteSignal,
                                std::bind(&Server::SignalHandler, this, std::placeholders::_1));

    Ecore_Con_Server *Server;
    if (!(Server = ecore_con_server_add(ECORE_CON_REMOTE_TCP, "127.0.0.1", 8888, NULL)))
    {
        _E("Fail to add server");
        return;
    }

   ecore_event_handler_add(ECORE_CON_EVENT_CLIENT_ADD, (Ecore_Event_Handler_Cb)ClientAddCallback, NULL);
   ecore_event_handler_add(ECORE_CON_EVENT_CLIENT_DEL, (Ecore_Event_Handler_Cb)ClientDeleteCallback, NULL);
   ecore_event_handler_add(ECORE_CON_EVENT_CLIENT_DATA, (Ecore_Event_Handler_Cb)ClientDataCallback, NULL);

   ecore_con_server_timeout_set(Server, 120);
   ecore_con_server_client_limit_set(Server, 3, 0);
}

void Server::exit()
{
    _D("End");
}

