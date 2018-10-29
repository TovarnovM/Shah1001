/********************************************************************************
** Form generated from reading UI file 'qtoptim.ui'
**
** Created by: Qt User Interface Compiler version 5.9.5
**
** WARNING! All changes made in this file will be lost when recompiling UI file!
********************************************************************************/

#ifndef UI_QTOPTIM_H
#define UI_QTOPTIM_H

#include <QtCore/QVariant>
#include <QtWidgets/QAction>
#include <QtWidgets/QApplication>
#include <QtWidgets/QButtonGroup>
#include <QtWidgets/QCommandLinkButton>
#include <QtWidgets/QHeaderView>
#include <QtWidgets/QMainWindow>
#include <QtWidgets/QMenuBar>
#include <QtWidgets/QPushButton>
#include <QtWidgets/QStatusBar>
#include <QtWidgets/QToolBar>
#include <QtWidgets/QWidget>

QT_BEGIN_NAMESPACE

class Ui_QtOptimClass
{
public:
    QWidget *centralWidget;
    QPushButton *pushButton;
    QCommandLinkButton *commandLinkButton;
    QCommandLinkButton *commandLinkButton_2;
    QMenuBar *menuBar;
    QToolBar *mainToolBar;
    QStatusBar *statusBar;

    void setupUi(QMainWindow *QtOptimClass)
    {
        if (QtOptimClass->objectName().isEmpty())
            QtOptimClass->setObjectName(QStringLiteral("QtOptimClass"));
        QtOptimClass->resize(600, 400);
        centralWidget = new QWidget(QtOptimClass);
        centralWidget->setObjectName(QStringLiteral("centralWidget"));
        pushButton = new QPushButton(centralWidget);
        pushButton->setObjectName(QStringLiteral("pushButton"));
        pushButton->setGeometry(QRect(20, 10, 81, 31));
        commandLinkButton = new QCommandLinkButton(centralWidget);
        commandLinkButton->setObjectName(QStringLiteral("commandLinkButton"));
        commandLinkButton->setGeometry(QRect(160, 120, 185, 41));
        commandLinkButton_2 = new QCommandLinkButton(centralWidget);
        commandLinkButton_2->setObjectName(QStringLiteral("commandLinkButton_2"));
        commandLinkButton_2->setGeometry(QRect(110, 220, 185, 41));
        QtOptimClass->setCentralWidget(centralWidget);
        menuBar = new QMenuBar(QtOptimClass);
        menuBar->setObjectName(QStringLiteral("menuBar"));
        menuBar->setGeometry(QRect(0, 0, 600, 21));
        QtOptimClass->setMenuBar(menuBar);
        mainToolBar = new QToolBar(QtOptimClass);
        mainToolBar->setObjectName(QStringLiteral("mainToolBar"));
        QtOptimClass->addToolBar(Qt::TopToolBarArea, mainToolBar);
        statusBar = new QStatusBar(QtOptimClass);
        statusBar->setObjectName(QStringLiteral("statusBar"));
        QtOptimClass->setStatusBar(statusBar);

        retranslateUi(QtOptimClass);

        QMetaObject::connectSlotsByName(QtOptimClass);
    } // setupUi

    void retranslateUi(QMainWindow *QtOptimClass)
    {
        QtOptimClass->setWindowTitle(QApplication::translate("QtOptimClass", "QtOptim", Q_NULLPTR));
        pushButton->setText(QApplication::translate("QtOptimClass", "PushButton", Q_NULLPTR));
        commandLinkButton->setText(QApplication::translate("QtOptimClass", "CommandLinkButton", Q_NULLPTR));
        commandLinkButton_2->setText(QApplication::translate("QtOptimClass", "CommandLinkButton", Q_NULLPTR));
    } // retranslateUi

};

namespace Ui {
    class QtOptimClass: public Ui_QtOptimClass {};
} // namespace Ui

QT_END_NAMESPACE

#endif // UI_QTOPTIM_H
