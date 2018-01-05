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

#ifndef __COMMON_H_
#define __COMMON_H_

#include <stdio.h>
#include <error.h>
#include <unistd.h>

#define ARRAY_SIZE(name) (sizeof(name)/sizeof(name[0]))

// It will be called before main
// It can be replaced with static instance in C++
#ifndef __CONSTRUCTOR__
#define __CONSTRUCTOR__ __attribute__ ((constructor))
#endif

// It will be called before main done
// It can be replaced with static instance in C++
#ifndef __DESTRUCTOR__
#define __DESTRUCTOR__ __attribute__ ((destructor))
#endif

#endif /* __COMMON_H_ */