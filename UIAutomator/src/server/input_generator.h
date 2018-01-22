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

#ifndef __INPUT_GENERATOR_H_
#define __INPUT_GENERATOR_H_

#include <string>
#include <vector>
#include <memory>
#include <mutex>
#include <condition_variable>

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

#define TRACKING_ID_MAX 65535

#define DEVICE_TOUCH 1

const int ABS_X_MID = 359;
const int ABS_Y_MID = 639;

class InputGenerator
{
public:
    InputGenerator();
    ~InputGenerator();

    static InputGenerator& getInstance();
    void Init();

	int OpenFile(const char *file_name);
	bool InitUinput();
	int GetCurrentTrackingId();
	void SendUinputEvent(int device, __u16 type, __u16 code, __s32 value);
	void SendUinputEventForKey(int device, __u16 code);
	void SendUinputEventForTouchMouse(int device, __s32 value_x, __s32 value_y);
	void SendUinputEventForTouchDown(int device, __s32 value_x, __s32 value_y);
	void SendUinputEventForTouchMove(int device, __s32 value_x, __s32 value_y);
	void SendUinputEventForTouchUp(int device, __s32 value_x, __s32 value_y);
	void SendUinputEventForFlick(int device, int xSpeed, int ySpeed);
private:
	int fd_uinput_mouse;
	int id;
};

#endif /* __INPUT_GENERATOR_H_ */