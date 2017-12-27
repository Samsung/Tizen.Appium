SET(SYSTEM_DBUS_SERVICE_DIR "${PREFIX}/share/dbus-1/services")

INSTALL(FILES
         ${CMAKE_SOURCE_DIR}/service/dbus/org.tizen.system.uiautomator.service
        DESTINATION
        ${SYSTEM_DBUS_SERVICE_DIR}
)
