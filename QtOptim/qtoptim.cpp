#include "qtoptim.h"
#include "rx.hpp"
namespace Rx {
	using namespace rxcpp;
	using namespace rxcpp::sources;
	using namespace rxcpp::operators;
	using namespace rxcpp::util;
}
using namespace Rx;

QtOptim::QtOptim(QWidget *parent)
	: QMainWindow(parent)
{
	ui.setupUi(this);
	connect(ui.pushButton, SIGNAL(clicked()), this, SLOT(someslot()));

}

void QtOptim::someslot() {
	ui.pushButton->setText("wwewe");
}
