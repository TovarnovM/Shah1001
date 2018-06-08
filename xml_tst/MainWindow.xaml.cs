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
using System.Xml.Schema;
using System.Xml.Linq;
using System.Xml;

namespace xml_tst {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window {
        public MainWindow() {
            InitializeComponent();

        }


        private void BuildTree(TreeView treeView, XDocument doc) {
            TreeViewItem treeNode = new TreeViewItem {
                //Should be Root
                Header = doc.Root.Name.LocalName,
                IsExpanded = true
            };
            treeView.Items.Add(treeNode);
            BuildNodes(treeNode, doc.Root);
        }

        private void BuildNodes(TreeViewItem treeNode, XElement element) {
            foreach (XNode child in element.Nodes()) {
                switch (child.NodeType) {
                    case XmlNodeType.Element:
                        XElement childElement = child as XElement;

                            var h = childElement.Name.ToString();
                            if (childElement.HasAttributes) {
                                foreach (var a in childElement.Attributes()) {
                                    h += " " + a.Name.ToString() + "=" + a.Value.ToString();
                                    var xname = a.BaseUri;
                                    var si = a.GetSchemaInfo();
                                    h += si.SchemaType != null ? $"({si.SchemaType.QualifiedName.Name }) " : "";
                                }

                            } 
                            
                            
                            TreeViewItem childTreeNode = new TreeViewItem {
                                //Get First attribute where it is equal to value
                                Header = h,
                                //Automatically expand elements
                                IsExpanded = true
                            };
                            treeNode.Items.Add(childTreeNode);
                            BuildNodes(childTreeNode, childElement);


                        break;
                    case XmlNodeType.Text:
                        XText childText = child as XText;
                        treeNode.Items.Add(new TreeViewItem { Header = childText.Value, });
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var xsd_path = @"D:\qt46\SIM\data\settings.xsd";
            var xml_path = @"D:\qt46\SIM\data\some.xml";
            var xdoc = XDocument.Load(xml_path);
            xdoc = new XDocument(xdoc);
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, xsd_path);
            string msg = "";
            xdoc.Validate(schemas, (o, e1) => {
                msg += e1.Message + Environment.NewLine;
            },true);
            btn.Content = msg == "" ? "Document is valid" : "Document invalid: " + msg;
            
            BuildTree(tv, xdoc);
        }
    }
}
