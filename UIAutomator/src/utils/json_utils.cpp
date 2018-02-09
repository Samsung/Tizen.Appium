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

#include "json_utils.h"

#include <json/json.h>
#include <glib.h>
#include <gio/gio.h>
#include <Ecore.h>
#include <Ecore_Con.h>

#include "log.h"

using namespace std;

JsonUtils::JsonUtils()
{
    _D("Enter");
}

JsonUtils::~JsonUtils()
{
    _D("Enter");
}

string JsonUtils::ActionReply(char* value)
{
    string data = value;
    Json::Value root;
    root["status"] = 0;
    root["value"] = data;
    Json::StyledWriter writer;
    std::string ret = writer.write(root);
    return ret;
}

string JsonUtils::ActionReply(string value)
{
    Json::Value root;
    root["status"] = 0;
    root["value"] = value;
    Json::StyledWriter writer;
    std::string ret = writer.write(root);
    return ret;
}

string JsonUtils::ActionReply(bool result)
{
    Json::Value root;
    root["status"] = 0;
    root["value"] = result;
    Json::StyledWriter writer;
    std::string ret = writer.write(root);
    return ret;
}

string JsonUtils::FindReply(string elementId)
{
    Json::Value root;
    root["status"] = 0;
    Json::Value list;
    list["ELEMENT"] = elementId;
    root["value"] = list;
    Json::StyledWriter writer;
    std::string ret = writer.write(root);
    return ret;
}

string JsonUtils::ReplyAxis(string key1, int value1, string key2, int value2 )
{
    Json::Value root;
    root["status"] = 0;

    Json::Value value;
    value[key1] = value1;
    value[key2] = value2;
    root["value"] = value;

    Json::StyledWriter writer;
    string ret = writer.write(root);
    return ret;
}


string JsonUtils::GetStringParam(char* data, string key)
{
    string buf = data;
    Json::Value root;
    Json::Reader reader;
    bool ret = reader.parse(buf, root);
    if(true == ret)
    {
        string value = root["params"][key].asString();
        return value;
    }
    else
    {
        _D("fail to parse %s in %s", key.c_str(),data);
        return "";
    }
}

int JsonUtils::GetIntParam(char* data, string key)
{
    string buf = data;
    Json::Value root;
    Json::Reader reader;
    bool ret = reader.parse(buf, root);
    if(true == ret)
    {
        int value = root["params"][key].asInt();
        return value;
    }
    else
    {
        _D("fail to parse %s in %s", key.c_str(),data);
        return -1;
    }
}

string JsonUtils::GetCommand(char* data)
{
    string buf = data;
    Json::Value root;
    Json::Reader reader;

    reader.parse(buf, root);
    string command = root.get("cmd","").asString();
    return command;
}

string JsonUtils::GetAction(char* data)
{
    string buf = data;
    Json::Value root;
    Json::Reader reader;

    reader.parse(buf, root);
    string action = root.get("action","").asString();
    return action;
}
