CMAKE_MINIMUM_REQUIRED(VERSION 2.6)
PROJECT(uiautomator)

SET(PACKAGE     ${PROJECT_NAME})
SET(PKGNAME     "${PROJECT_NAME}")
SET(PREFIX      "/usr")
SET(BINDIR      "${PREFIX}/bin")
SET(LIBDIR      "${PREFIX}/lib")
SET(INCLUDEDIR  "/usr/include")
SET(EXEC_PREFIX "${BINDIR}")

SET(SRCS
    UIAutomator/src/common/core.cpp
    UIAutomator/src/common/dbus_utils.cpp
)

SET(SRCS ${SRCS}
    UIAutomator/src/server/server.cpp
    UIAutomator/src/server/request.cpp
    UIAutomator/src/server/input_generator.cpp
    UIAutomator/src/server/json_utils.cpp
)

# -----------------------------------------------------------------------------
# Set build type (Release by default)
# -----------------------------------------------------------------------------

IF("${CMAKE_BUILD_TYPE}" STREQUAL "")
     SET(CMAKE_BUILD_TYPE Release)
ENDIF("${CMAKE_BUILD_TYPE}" STREQUAL "")
MESSAGE("Build type: ${CMAKE_BUILD_TYPE}")

# -----------------------------------------------------------------------------
# Required platform modules
# -----------------------------------------------------------------------------
INCLUDE(FindPkgConfig)

SET(PKG_MODULES
    dlog
    glib-2.0
    ecore
    elementary
    edbus
    jsoncpp 
    gio-2.0
    dbus-glib-1
    edbus
)
PKG_CHECK_MODULES(pkgs REQUIRED ${PKG_MODULES})

FOREACH(flag ${pkgs_CFLAGS})
    SET(EXTRA_CFLAGS "${EXTRA_CFLAGS} ${flag}")
ENDFOREACH(flag)

# -----------------------------------------------------------------------------
# CFlags
# -----------------------------------------------------------------------------
SET(CMAKE_CXX_FLAGS_PROFILING  "-O0 -std=c++0x -g -pg")
SET(CMAKE_CXX_FLAGS_DEBUG      "-O0 -std=c++0x -g")
SET(CMAKE_CXX_FLAGS_RELEASE    "-O3 -std=c++0x -Wall -pthread ${EXTRA_CFLAGS}")

 
INCLUDE_DIRECTORIES(
    ${CMAKE_CURRENT_SOURCE_DIR}/src/
    ${pkgs_INCLUDE_DIRS}
)

ADD_DEFINITIONS("-DUIAUTOMATOR_DLOG")

ADD_EXECUTABLE(${PROJECT_NAME} ${SRCS})
TARGET_LINK_LIBRARIES(${PROJECT_NAME} ${pkgs_LDFLAGS} "-lm -ldl -lrt")
INSTALL(TARGETS ${PROJECT_NAME} DESTINATION ${BINDIR})

INSTALL(FILES ${PROJECT_BINARY_DIR}/packaging/${PROJECT_NAME}.rule DESTINATION /etc/smack/accesses.d)
INSTALL(FILES ${PROJECT_BINARY_DIR}/LICENSE DESTINATION share/license RENAME ${PROJECT_NAME})

MESSAGE( STATUS "PROJECT_BINARY_DIR: " ${PROJECT_BINARY_DIR} )
MESSAGE( STATUS "CMAKE_CURRENT_SOURCE_DIR: " ${CMAKE_CURRENT_SOURCE_DIR} )

ADD_SUBDIRECTORY(service)