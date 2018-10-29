#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_qtoptim.h"

class QtOptim : public QMainWindow
{
	Q_OBJECT

public:
	QtOptim(QWidget *parent = Q_NULLPTR);

private:
	Ui::QtOptimClass ui;

private slots:
	void someslot();
};
