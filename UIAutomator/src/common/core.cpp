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

#include "log.h"

#include <Ecore.h>
#include <Ecore_Con.h>
#include <signal.h>
#include <E_DBus.h>
#include "server/server.h"
#include "inputgenerator/input_generator.h"

static void sig_quit(int signo)
{
    _D("received SIGTERM signal %d", signo);
}

static void sig_usr1(int signo)
{
    _D("received SIGUSR1 signal %d, service will be finished!", signo);

    ecore_main_loop_quit();
}

static void sig_usr2(int signo)
{
    _D("received SIGUSR2 signal %d,", signo);
}

static int uiautomator_init(int argc, char **argv)
{
    _D("Enter");

    Server::getInstance().init();

    signal(SIGTERM, sig_quit); // SIGTERM signal termination - 15
    signal(SIGUSR1, sig_usr1); // SIGUSR1 - 10
    signal(SIGUSR2, sig_usr2); // SIGUSR2 - 12

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
