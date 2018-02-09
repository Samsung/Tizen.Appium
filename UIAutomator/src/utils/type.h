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

#ifndef __TYPE_H_
#define __TYPE_H_

#include <iostream>
#include <string>

const std::string COMMAND_SHUTDOWN = "shutdown";
const std::string COMMAND_ACTION = "action";

const std::string ACTION_FIND = "find";
const std::string ACTION_FLICK = "flick";
const std::string ACTION_INPUT_TEXT = "inputText";
const std::string ACTION_CLICK = "click";
const std::string ACTION_TOUCH_DOWN = "touchDown";
const std::string ACTION_TOUCH_UP = "touchUp";
const std::string ACTION_TOUCH_MOVE = "touchMove";
const std::string ACTION_TOUCH_LONG_CLICK = "touchLongClick";
const std::string ACTION_GET_ATTRIBUTE = "element:getAttribute";
const std::string ACTION_SET_ATTRIBUTE = "element:SetAttribute";
const std::string ACTION_GET_SIZE = "element:getSize";
const std::string ACTION_GET_LOCATION = "element:getLocation";

const std::string ACTION_PRESS_HARDWARE_KEY = "pressHardWareKey";

const std::string ATTRIBUTE_TEXT = "text";
const std::string ATTRIBUTE_ENABLED = "enabled";
const std::string ATTRIBUTE_NAME = "name";
const std::string ATTRIBUTE_DISPLAYED = "displayed";
const std::string ATTRIBUTE_SIZE = "size";

const std::string BusName = "org.tizen.appium";
const std::string ObjectPath = "/org/tizen/appium";
const std::string InterfaceName = "org.tizen.appium";

const std::string GetPositionMethod = "GetPosition";
const std::string SetCommandMethod = "SetCommand";

const std::string CompleteSignal = "Complete";

#endif /* __TYPE_H_ */
