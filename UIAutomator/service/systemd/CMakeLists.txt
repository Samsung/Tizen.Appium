SET(SD_SYS_UNIT_DIR "${LIBDIR}/systemd/system")

SET(SD_SYS_UNITS
	uiautomator.service
)

INSTALL(FILES
	${CMAKE_SOURCE_DIR}/service/systemd/${SD_SYS_UNITS}
	DESTINATION
	${SD_SYS_UNIT_DIR}
)