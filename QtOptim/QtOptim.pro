# ----------------------------------------------------
# This file is generated by the Qt Visual Studio Tools.
# ------------------------------------------------------

TEMPLATE = app
TARGET = QtOptim
DESTDIR = ../x64/Debug
QT += core xml gui xmlpatterns widgets qml datavisualization
CONFIG += debug
DEFINES += _UNICODE WIN64 QT_DLL QT_DATAVISUALIZATION_LIB QT_QML_LIB QT_WIDGETS_LIB QT_XML_LIB QT_XMLPATTERNS_LIB
INCLUDEPATH += ./GeneratedFiles \
    . \
    ./GeneratedFiles/$(ConfigurationName)
DEPENDPATH += .
MOC_DIR += ./GeneratedFiles/$(ConfigurationName)
OBJECTS_DIR += debug
UI_DIR += ./GeneratedFiles
RCC_DIR += ./GeneratedFiles
include(QtOptim.pri)
