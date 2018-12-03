#include "qtoptim.h"
#include "rx.hpp"
#include "DRange.h"
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
	auto dr = DRange(1, 2, "123");
	ui.pushButton->setText(dr.name);
}
