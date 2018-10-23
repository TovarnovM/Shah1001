#include "qtoptim.h"
#include <QtWidgets/QApplication>

int main(int argc, char *argv[])
{
	QApplication a(argc, argv);
	QtOptim w;
	w.show();
	return a.exec();
}
