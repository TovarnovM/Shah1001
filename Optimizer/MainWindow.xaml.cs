using Optimizer.Models;
using Optimizer.VievModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Optimizer {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window {
        public TreeMaker Tm { get; set; }

        public MainWindow() {
            InitializeComponent();
            Just4tst();
            ChooseAttrXmlView.DataContext = new TreeXMLViewModel(Tm.Tree);           
        }

        void Just4tst() {
            var xsd_path = @"D:\qt46\SIM\data\settings.xsd";
            var xml_path = @"D:\qt46\SIM\data\some.xml";
            var xdoc = XDocument.Load(xml_path);
            xdoc = new XDocument(xdoc);
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, xsd_path);

            var tm = new TreeMaker(xdoc, schemas);
            tm.AddSpecialIDsToDoc();
            tm.BuildTreeView(tv_xml);
            textBlock_xml.Text = tm.GetDocString();

            tm.Tree = tm.ConstructTree();
            this.Tm = tm;

        }
    }
}
