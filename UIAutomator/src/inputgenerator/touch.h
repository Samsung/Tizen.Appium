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
#include <tgmath.h>
#include <algorithm>

#define TRACKING_ID_MAX 65535

class Touch : InputGenerator
{
public:
    Touch();
    ~Touch();
    void Click(int x, int y);
    void Up(int x, int y);
    void Down(int x, int y);
    void Move(int x, int y);
    void LongPress(int x, int y, int duration);
    void Flick(int xSpeed, int ySpeed);
    void Swipe(int xDown, int yDown, int xUp, int yUp, int steps);

protected:
    virtual bool Initialize();
    virtual bool SetInputCodes();
    virtual void SetDeviceInformation();

private:
    struct Point
    {
        int x;
        int y;
    };
    const int ABS_X_MID = 359;
    const int ABS_X_MAX = 639;
    const int ABS_Y_MID = 719;
    const int ABS_Y_MAX = 1279;
    int tracking_id;

    int GetCurrentTrackingId();
    Point GetEndPoint(int xStart, int yStart, int xSpeed, int ySpeed);
    int SigNumber(int number);
};