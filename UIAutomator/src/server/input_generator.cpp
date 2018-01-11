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

#include "input_generator.h"
#include "common/log.h"

#include <glib.h>
#include <stdio.h>
#include <stdlib.h>
#include <netdb.h>
#include <sys/socket.h>
#include <string.h>
#include <unistd.h>
#include <sys/un.h>
#include <fcntl.h>
#include <errno.h>
#include <sys/ioctl.h>
#include <signal.h>
#include <assert.h>
#include <math.h>
#include <tizen_error.h>
#include <math.h>

#include <linux/input.h>
#include <linux/uinput.h>

using namespace std;

InputGenerator::InputGenerator()
{
	fd_uinput_mouse = 0;
}

InputGenerator::~InputGenerator()
{
    _D("Enter");
}

InputGenerator& InputGenerator::getInstance()
{
    static InputGenerator instance;
    return instance;
}

void InputGenerator::Init()
{
    _D("Enter");
    InitUinput();
}


int InputGenerator::OpenFile(const char *file_name) 
{
    int file_descriptor = -1;
    char *resolved_path = realpath(file_name, NULL);

    if (resolved_path && !strcmp(file_name, resolved_path))
        file_descriptor = open(file_name, O_WRONLY | O_NONBLOCK);

    return file_descriptor;
}


bool InputGenerator::InitUinput()
{
	id = 1;

    struct uinput_user_dev device_mouse;
    memset(&device_mouse, 0, sizeof device_mouse);

     const char *file_name = "/dev/uinput";
    fd_uinput_mouse = open(file_name, O_WRONLY | O_NONBLOCK);
     
    if (fd_uinput_mouse < 0) {
        _D ("Fail to open fd uinput_mouse!\n");
        return false;
    }

    const char *dev_name = "Remote-Input(Mouse)";
    strncpy(device_mouse.name, dev_name, sizeof(device_mouse.name) - 1);
    device_mouse.id.bustype = BUS_USB;
    device_mouse.id.vendor = 1;
    device_mouse.id.product = 1;
    device_mouse.id.version = 1;

    if (ioctl(fd_uinput_mouse, UI_SET_EVBIT, EV_SYN) < 0) {
        _D ("Fail ioctl method");
        return false;
    }

    if (ioctl(fd_uinput_mouse, UI_SET_EVBIT, EV_KEY) < 0) {
        _D ("Fail ioctl method");
        return false;
    }

    if (ioctl(fd_uinput_mouse, UI_SET_EVBIT, EV_ABS) < 0) {
        _D ("Fail ioctl method");
        return false;
    }

    if (ioctl(fd_uinput_mouse, UI_SET_KEYBIT, BTN_TOUCH) < 0) {
        _D ("Fail ioctl method");
        return false;
    }

    if (ioctl(fd_uinput_mouse, UI_SET_ABSBIT, ABS_X) < 0) {
        _D ("Fail ioctl method");
        return false;
    }

    if (ioctl(fd_uinput_mouse, UI_SET_ABSBIT, ABS_Y) < 0) {
        _D ("Fail ioctl method");
        return false;
    }

    if (ioctl(fd_uinput_mouse, UI_SET_ABSBIT, ABS_MT_SLOT) < 0) {  // slot
        _D ("Fail ioctl method");
        return false;
    }
    if (ioctl(fd_uinput_mouse, UI_SET_ABSBIT, ABS_MT_TOUCH_MAJOR) < 0) {  // MT Touch Major
        _D ("Fail ioctl method");
        return false;
    }
    if (ioctl(fd_uinput_mouse, UI_SET_ABSBIT, ABS_MT_WIDTH_MAJOR) < 0) {  // MT width Major
        _D ("Fail ioctl method");
        return false;
    }
    if (ioctl(fd_uinput_mouse, UI_SET_ABSBIT, ABS_MT_POSITION_X) < 0) {  // MT Position X
        _D ("Fail ioctl method");
        return false;
    }
    if (ioctl(fd_uinput_mouse, UI_SET_ABSBIT, ABS_MT_POSITION_Y) < 0) {  // MT Position Y 
        _D ("Fail ioctl method");
        return false;
    }
    if (ioctl(fd_uinput_mouse, UI_SET_ABSBIT, ABS_MT_TRACKING_ID) < 0) {  // MT Tacking ID
        _D ("Fail ioctl method");
        return false;
    }

	device_mouse.absmin[ABS_X] = 0;
    device_mouse.absmax[ABS_X] = 719;
	device_mouse.absmin[ABS_Y] = 0;
    device_mouse.absmax[ABS_Y] = 1279;
	device_mouse.absmin[ABS_MT_SLOT] = 0;
    device_mouse.absmax[ABS_MT_SLOT] = 1;
    device_mouse.absmin[ABS_MT_TOUCH_MAJOR] = 0;
    device_mouse.absmax[ABS_MT_TOUCH_MAJOR] = 15;
    device_mouse.absmin[ABS_MT_WIDTH_MAJOR] = 0;
    device_mouse.absmax[ABS_MT_WIDTH_MAJOR] = 255;
    device_mouse.absmin[ABS_MT_POSITION_X] = 0;
    device_mouse.absmax[ABS_MT_POSITION_X] = 719;
    device_mouse.absmin[ABS_MT_POSITION_Y] = 0;
    device_mouse.absmax[ABS_MT_POSITION_Y] = 1279;
    device_mouse.absmin[ABS_MT_TRACKING_ID] = 0;
    device_mouse.absmax[ABS_MT_TRACKING_ID] = 65535;

    if (write(fd_uinput_mouse, &device_mouse, sizeof(device_mouse)) != sizeof(device_mouse)) {
        _D ("Fail to setup uinput structure on fd\n");
        return false;
    }

    if (ioctl(fd_uinput_mouse, UI_DEV_CREATE) < 0) {
        _D ("Fail to create keyboard uinput device\n");
        return false;
    }

    return true;
}

void InputGenerator::SendUinputEvent(int device, __u16 type, __u16 code, __s32 value)
{
    struct input_event event;

    memset(&event, 0, sizeof(event));
    event.type = type;
    event.code = code;
    event.value = value;
    
    if (device == 1) {
        if (write(fd_uinput_mouse, &event, sizeof(event)) != sizeof(event)) {
            _D ("Error to send uinput event");
        }
    }
    else {
        _D ("Fail to send uinput event because of device name!");
    }
}

void InputGenerator::SendUinputEventForKey(int device, __u16 code)
{
    SendUinputEvent (device, EV_KEY, code, 1);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);
    SendUinputEvent (device, EV_KEY, code, 0);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);
}

int InputGenerator::GetCurrentTrackingId()
{
    id++;
    if(id >= TRACKING_ID_MAX){
        id = 1;
    }
    return id;
}

void InputGenerator::SendUinputEventForTouchMouse(int device, __s32 value_x, __s32 value_y)
{
    struct timespec sleeptime = {0, 50}; //speed (low value: fast, high value: slow)
    _D("X = %d,  Y = %d", value_x, value_y);

    int nowId = GetCurrentTrackingId();
    SendUinputEvent (device, EV_ABS, ABS_MT_TRACKING_ID, nowId);
    SendUinputEvent (device, EV_KEY, BTN_TOUCH, 1);
    SendUinputEvent (device, EV_ABS, ABS_MT_POSITION_X, value_x);
    SendUinputEvent (device, EV_ABS, ABS_MT_POSITION_Y, value_y);
    SendUinputEvent (device, EV_ABS, ABS_MT_TOUCH_MAJOR, 4);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);

    nanosleep(&sleeptime, NULL);

    SendUinputEvent (device, EV_ABS, ABS_MT_TRACKING_ID, -1);
    SendUinputEvent (device, EV_KEY, BTN_TOUCH, 0);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);

    nanosleep(&sleeptime, NULL);
}

void InputGenerator::SendUinputEventForTouchDown(int device, __s32 value_x, __s32 value_y)
{
    struct timespec sleeptime = {0, 50}; //speed (low value: fast, high value: slow)
    _D("X = %d,  Y = %d", value_x, value_y);

    int nowId = GetCurrentTrackingId();
    SendUinputEvent (device, EV_ABS, ABS_MT_TRACKING_ID, nowId);
    SendUinputEvent (device, EV_KEY, BTN_TOUCH, 1);
    SendUinputEvent (device, EV_ABS, ABS_MT_POSITION_X, value_x);
    SendUinputEvent (device, EV_ABS, ABS_MT_POSITION_Y, value_y);
    SendUinputEvent (device, EV_ABS, ABS_MT_TOUCH_MAJOR, 4);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);

    nanosleep(&sleeptime, NULL);
    /*
    SendUinputEvent (device, EV_ABS, ABS_MT_TRACKING_ID, -1);
    SendUinputEvent (device, EV_KEY, BTN_TOUCH, 0);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);

    nanosleep(&sleeptime, NULL);
    */
}

void InputGenerator::SendUinputEventForTouchUp(int device, __s32 value_x, __s32 value_y)
{
    struct timespec sleeptime = {0, 50}; //speed (low value: fast, high value: slow)
    _D("X = %d,  Y = %d", value_x, value_y);

    int nowId = GetCurrentTrackingId();
    SendUinputEvent (device, EV_ABS, ABS_MT_TRACKING_ID, nowId);
    SendUinputEvent (device, EV_KEY, BTN_TOUCH, 1);
    SendUinputEvent (device, EV_ABS, ABS_MT_POSITION_X, value_x);
    SendUinputEvent (device, EV_ABS, ABS_MT_POSITION_Y, value_y);
    SendUinputEvent (device, EV_ABS, ABS_MT_TOUCH_MAJOR, 4);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);

    nanosleep(&sleeptime, NULL);

    SendUinputEvent (device, EV_ABS, ABS_MT_TRACKING_ID, -1);
    SendUinputEvent (device, EV_KEY, BTN_TOUCH, 0);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);

    nanosleep(&sleeptime, NULL);
}


void InputGenerator::SendUinputEventForWheel(int device, __s32 value_y)
{
    struct timespec sleeptime = {0, 800000};
    __s32 y;

    y = value_y / 4;

    _D("wheel value : %d, %d", value_y, y);
    SendUinputEvent (device, EV_REL, REL_WHEEL, y);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);
    nanosleep(&sleeptime, NULL);
}

void InputGenerator::SendUinputEventForFlick(int device, int xSpeed, int ySpeed)
{
    struct timespec sleeptime = {0, 8000}; //speed (low value: fast, high value: slow)
    _D("xSpped %d, ySpeed %d", xSpeed, ySpeed);

    double ratio = (double) xSpeed / ySpeed;
    int yDiff = 0;
    int xDiff = 0;
    int xCurrent = ABS_X_MID;
    int yCurrent = ABS_Y_MID;

    if(ratio < 1)
    {
        yDiff = ABS_X_MID / (4 * 6);
        xDiff = ABS_X_MID / (4 * 6) * ratio;
    }
    else
    {
        yDiff = ABS_X_MID / (4 * 6) * ratio;
        xDiff = ABS_X_MID / (4 * 6);
    }

    int nowId = GetCurrentTrackingId();
    SendUinputEvent (device, EV_ABS, ABS_MT_TRACKING_ID, nowId);
    SendUinputEvent (device, EV_KEY, BTN_TOUCH, 1);
    SendUinputEvent (device, EV_ABS, ABS_MT_POSITION_X, xCurrent);
    SendUinputEvent (device, EV_ABS, ABS_MT_POSITION_Y, yCurrent);
    SendUinputEvent (device, EV_ABS, ABS_MT_TOUCH_MAJOR, 4);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);
    nanosleep(&sleeptime, NULL);

    for(int i=1 ; i<=6 ; i++)
    {
        xCurrent = xCurrent - xDiff;
        yCurrent = yCurrent - yDiff;
        SendUinputEvent (device, EV_ABS, ABS_MT_POSITION_X, xCurrent);
        SendUinputEvent (device, EV_ABS, ABS_MT_POSITION_Y, yCurrent);
        SendUinputEvent (device, EV_ABS, ABS_MT_TOUCH_MAJOR, 3);
        SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);
        //_D("X %d, Y %d", xCurrent, yCurrent);
        nanosleep(&sleeptime, NULL);
    }
    
    SendUinputEvent (device, EV_ABS, ABS_MT_TRACKING_ID, -1);
    SendUinputEvent (device, EV_KEY, BTN_TOUCH, 0);
    SendUinputEvent (device, EV_SYN, SYN_REPORT, 0);
    nanosleep(&sleeptime, NULL);
}