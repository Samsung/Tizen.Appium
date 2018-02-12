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

#include "touch.h"

Touch::Touch() {
    Initialize();
}
Touch::~Touch() {}

bool Touch::Initialize() {
    memset(&device_information, 0, sizeof device_information);

    const char *file_name = "/dev/uinput";
    fake_device = open(file_name, O_WRONLY | O_NONBLOCK);

    if (fake_device < 0) {
        _D("Fail to open fake uinput device!\n");
        return false;
    }

    SetInputCodes();
    SetDeviceInformation();

    if (write(fake_device, &device_information, sizeof(device_information)) != sizeof(device_information)) {
        _D("Fail to setup uinput structure on fake device\n");
        return false;
    }

    if (ioctl(fake_device, UI_DEV_CREATE) < 0) {
        _D("Fail to create touch uinput device\n");
        return false;
    }

    return true;
}

void Touch::Click(int x, int y) {
    struct timespec sleeptime = { 0, 50 }; //speed (low value: fast, high value: slow)
    _D("X = %d,  Y = %d", x, y);

    Down(x, y);
    Up(x, y);
}

void Touch::Down(int x, int y) {
    struct timespec sleeptime = { 0, 50 }; //speed (low value: fast, high value: slow)
    _D("X = %d,  Y = %d", x, y);

    int nowId = GetCurrentTrackingId();
    SendInputEvent(fake_device, EV_ABS, ABS_MT_TRACKING_ID, nowId);
    SendInputEvent(fake_device, EV_KEY, BTN_TOUCH, 1);
    SendInputEvent(fake_device, EV_ABS, ABS_MT_POSITION_X, x);
    SendInputEvent(fake_device, EV_ABS, ABS_MT_POSITION_Y, y);
    SendInputEvent(fake_device, EV_ABS, ABS_MT_TOUCH_MAJOR, 4);
    SendInputEvent(fake_device, EV_SYN, SYN_REPORT, 0);

    nanosleep(&sleeptime, NULL);
}

void Touch::Up(int x, int y) {
    struct timespec sleeptime = { 0, 50 }; //speed (low value: fast, high value: slow)
    _D("X = %d,  Y = %d", x, y);

    SendInputEvent(fake_device, EV_ABS, ABS_MT_TRACKING_ID, -1);
    SendInputEvent(fake_device, EV_KEY, BTN_TOUCH, 0);
    SendInputEvent(fake_device, EV_SYN, SYN_REPORT, 0);

    nanosleep(&sleeptime, NULL);
}

void Touch::Move(int x, int y) {
    struct timespec sleeptime = { 0, 50 }; //speed (low value: fast, high value: slow)
    _D("X = %d,  Y = %d", x, y);

    SendInputEvent(fake_device, EV_ABS, ABS_MT_POSITION_X, x);
    SendInputEvent(fake_device, EV_ABS, ABS_MT_POSITION_Y, y);
    SendInputEvent(fake_device, EV_ABS, ABS_MT_TOUCH_MAJOR, 3);
    SendInputEvent(fake_device, EV_SYN, SYN_REPORT, 0);
    nanosleep(&sleeptime, NULL);
}

void Touch::LongPress(int x, int y, int duration) {
    //TO DO
    // need implement
}

void Touch::Flick(int xSpeed, int ySpeed) {
    struct timespec sleeptime = { 0, 8000 }; //speed (low value: fast, high value: slow)
    _D("xSpped %d, ySpeed %d", xSpeed, ySpeed);

    double speed = min(1250.0, sqrt((xSpeed * xSpeed) + (ySpeed * ySpeed)));
    double steps = 1250.0 / speed;

    int xStart = ABS_X_MID;
    int yStart = ABS_Y_MID;

    Point endPoint = GetEndPoint(xStart, yStart, xSpeed, ySpeed);

    Swipe(xStart, yStart, endPoint.x, endPoint.y, steps);
}

void Touch::Swipe(int xDown, int yDown, int xUp, int yUp, int steps) {
    int swipeSteps = steps;
    double xStep = 0;
    double yStep = 0;

    if (swipeSteps == 0) {
        swipeSteps = 1;
    }

    xStep = ((double)(xUp - xDown)) / swipeSteps;
    yStep = ((double)(yUp - yDown)) / swipeSteps;
    Down(xDown, yDown);
    for (int i = 0; i < swipeSteps; i++) {
        Move(xDown + (int)(xStep * i), yDown + (int)(yStep * i));
    }
    Up(xUp, yUp);
}

int Touch::GetCurrentTrackingId() {
    tracking_id++;
    if (tracking_id >= TRACKING_ID_MAX) {
        tracking_id = 1;
    }
    return tracking_id;
}

Touch::Point Touch::GetEndPoint(int xStart, int yStart, int xSpeed, int ySpeed) {
    double xDiff;
    double yDiff;
    int speedX = xSpeed;
    int speedY = ySpeed;

    if (speedX == 0) {
        speedX = 1;
    }
    else if(speedX < 0){
        speedX = speedX * -1;
    }

    if (speedY == 0) {
        speedY = 1;
    }
    else if (speedY < -1){
        speedY = speedY * -1;
    }
    double ratio = (double)speedX / speedY;

    if (ratio < 1)
    {
        xDiff = ABS_X_MAX / 4 * ratio;
        yDiff = ABS_Y_MAX / 4;
    }
    else
    {
        xDiff = ABS_X_MAX / 4;
        yDiff = ABS_Y_MAX / 4 / ratio;
    }

    xDiff = SigNumber(xSpeed) * xDiff;
    yDiff = SigNumber(ySpeed) * yDiff;

    Point endPoint;
    endPoint.x = (int)(xStart + xDiff);
    endPoint.y = (int)(yStart + yDiff);

    return endPoint;
}

int Touch::SigNumber(int number) {
    if (number > 0) {
        return 1;
    }
    else if (number == 0) {
        return 0;
    }
    else {
        return -1;
    }
}

bool Touch::SetInputCodes() {
    if (ioctl(fake_device, UI_SET_EVBIT, EV_SYN) < 0) {
        _D("Fail ioctl method");
        return false;
    }

    if (ioctl(fake_device, UI_SET_EVBIT, EV_ABS) < 0) {
        _D("Fail ioctl method");
        return false;
    }

    if (ioctl(fake_device, UI_SET_EVBIT, EV_KEY) < 0) {
        _D("Fail ioctl method");
        return false;
    }

    if (ioctl(fake_device, UI_SET_KEYBIT, BTN_TOUCH) < 0) {
        _D("Fail ioctl method");
        return false;
    }

    if (ioctl(fake_device, UI_SET_ABSBIT, ABS_MT_SLOT) < 0) {  // slot
        _D("Fail ioctl method");
        return false;
    }
    if (ioctl(fake_device, UI_SET_ABSBIT, ABS_MT_TOUCH_MAJOR) < 0) {  // MT Touch Major
        _D("Fail ioctl method");
        return false;
    }
    if (ioctl(fake_device, UI_SET_ABSBIT, ABS_MT_WIDTH_MAJOR) < 0) {  // MT width Major
        _D("Fail ioctl method");
        return false;
    }
    if (ioctl(fake_device, UI_SET_ABSBIT, ABS_MT_POSITION_X) < 0) {  // MT Position X
        _D("Fail ioctl method");
        return false;
    }
    if (ioctl(fake_device, UI_SET_ABSBIT, ABS_MT_POSITION_Y) < 0) {  // MT Position Y
        _D("Fail ioctl method");
        return false;
    }
    if (ioctl(fake_device, UI_SET_ABSBIT, ABS_MT_TRACKING_ID) < 0) {  // MT Tacking ID
        _D("Fail ioctl method");
        return false;
    }
    return true;
}

void Touch::SetDeviceInformation() {
    const char *device_name = "Remote-Input(Touch)";
    strncpy(device_information.name, device_name, sizeof(device_information.name) - 1);
    device_information.id.bustype = BUS_USB;
    device_information.id.vendor = 1;
    device_information.id.product = 1;
    device_information.id.version = 1;

    device_information.absmin[ABS_MT_SLOT] = 0;
    device_information.absmax[ABS_MT_SLOT] = 1;
    device_information.absmin[ABS_MT_TOUCH_MAJOR] = 0;
    device_information.absmax[ABS_MT_TOUCH_MAJOR] = 15;
    device_information.absmin[ABS_MT_WIDTH_MAJOR] = 0;
    device_information.absmax[ABS_MT_WIDTH_MAJOR] = 255;
    device_information.absmin[ABS_MT_POSITION_X] = 0;
    device_information.absmax[ABS_MT_POSITION_X] = 719;
    device_information.absmin[ABS_MT_POSITION_Y] = 0;
    device_information.absmax[ABS_MT_POSITION_Y] = 1279;
    device_information.absmin[ABS_MT_TRACKING_ID] = 0;
    device_information.absmax[ABS_MT_TRACKING_ID] = 65535;
}
