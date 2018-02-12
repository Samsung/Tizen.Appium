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

#include <Ecore.h>
#include <Ecore_Con.h>

#include "utils/log.h"
#include "input_generator/input_generator.h"
#include "server/server.h"

static int uiautomator_init(int argc, char **argv)
{
    _D("Enter");

    Server::getInstance().init();

    ecore_main_loop_begin();
    ecore_shutdown();
    return 0;
}

int main (int argc, char **argv)
{
    _D("UIAutomator start");
    eina_init();
    ecore_init();
    ecore_con_init();
    return uiautomator_init(argc, argv);
}
