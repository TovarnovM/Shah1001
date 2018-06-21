using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Optimizer.Models {
    public class TreeMaker: NotifyBase {
        public string ValidMsg { get; private set; }
        public bool IsValid {
            get {
                string msg = "";
                Doc.Validate(Schema, (o, e1) => {
                    msg += e1.Message + Environment.NewLine;
                }, true);
                ValidMsg = msg == "" ? "Document is valid" : "Document invalid: " + msg;
                return msg == "";
            }
        }
        string IdAttributeName { get; set; } = "optimid";
        HashSet<string> DoubleOptimAttrTypes { get; set; } = new HashSet<string>(new string[] {
            "double",
            "incPositiveDouble",
            "exPositiveDouble",
            "Percent"
        });
        HashSet<string> IntOptimAttrTypes { get; set; } = new HashSet<string>(new string[] {
            "int",
            "exPositiveInt"
        });
        public HashSet<string> ValidAttrs {
            get {
                var res = new HashSet<string>(DoubleOptimAttrTypes);
                res.UnionWith(IntOptimAttrTypes);
                return res;
            }
        }

        public TreeMaker(XDocument doc, XmlSchemaSet schema) {
            Doc = doc;
            Schema = schema;
            if (!IsValid)
                throw new ArgumentException("xml Не соответствует схеме: " + ValidMsg);

        }
        #region Tree
        public TreeNode Tree { get; set; }

        public XDocument Doc { get; }
        public XmlSchemaSet Schema { get; }

        public IEnumerable<XElement> GetElements(XElement element) {
            foreach (var xnode in element.Nodes()) {
                if (xnode is XElement) {
                    var res = xnode as XElement;
                    yield return res;
                    foreach (var ch in GetElements(res)) {
                        yield return ch;
                    }
                }
            }
        }
        public IEnumerable<XElement> GetElements() {
            return GetElements(Doc.Root);
        }

        void AddAttr(XElement element, string attrName, string attrValue) {
            XAttribute attr = new XAttribute(attrName, attrValue);
            element.Add(attr);
        }
        bool HasAttr(XElement element, string attrName) {
            if (element.HasAttributes) {
                foreach (var attr in element.Attributes()) {
                    if (attr.Name.ToString() == attrName) {
                        return true;
                    }
                }
            }

            return false;
        }

        public void AddSpecialIDsToDoc() {
            var allXEl = GetElements().ToList();
            var nodes_count = allXEl.Count;
            while (allXEl.Any(xel => HasAttr(xel, IdAttributeName))) {
                IdAttributeName += "7";
            }
            int id = 0;
            foreach (var xel in allXEl) {
                AddAttr(xel, IdAttributeName, $"{id++}");
            }


        }

        public TreeNode ConstructTree() {
            var xmlRoot = Doc.Root;
            var treeRoot = new TreeNode(xmlRoot.Name.ToString()) {
                Element = xmlRoot,
                Id = "-1"
            };
            foreach (var xnode in xmlRoot.Nodes()) {
                if (xnode is XElement) {
                    ConstructSubTree(xnode as XElement, treeRoot, ValidAttrs);
                }
            }
            Tree = treeRoot;
            return Tree;
        }
        public void ConstructSubTree(XElement elem, TreeNode parent, HashSet<string> goodAttsTypes) {
            var res = new TreeNode(elem.Name.ToString(), parent) {
                Id = elem.Attribute(IdAttributeName).Value,
                Element = elem
            };
            foreach (var attr in elem.Attributes()) {

                var si = attr.GetSchemaInfo();
                if (si == null)
                    continue;
                var atypeName = si?.SchemaType != null ? $"{si.SchemaType.QualifiedName.Name }" : "";
                if (!goodAttsTypes.Contains(atypeName))
                    continue;

                var nodeAttr = new NodeAttribute() {
                    Name = attr.Name.ToString(),
                    Value = attr.Value,
                    XsdType = atypeName,
                    Parent = res,
                    CheckUnCheckAction = CheckUnCheckAttrAction
                };
                res.Attrs.Add(nodeAttr);
            }
            foreach (var xnode in elem.Nodes()) {
                if (xnode is XElement) {
                    ConstructSubTree(xnode as XElement, res, ValidAttrs);
                }
            }
        }
        #endregion

        #region VarList

        public ObservableCollection<NodeAttribute> VariableAttrs { get; set; } = new ObservableCollection<NodeAttribute>();
        public void CheckUnCheckAttrAction(NodeAttribute changeAttr) {
            if (changeAttr.IsVariate) {
                if (!VariableAttrs.Contains(changeAttr)) {
                    VariableAttrs.Add(changeAttr);
                }
            } else {
                if (VariableAttrs.Contains(changeAttr)) {
                    VariableAttrs.Remove(changeAttr);
                }
            }
        }
        #endregion
        #region TMP
        public string GetDocString() {
            return Doc.Root.ToString();
        } 
        public void BuildTreeView(TreeView treeView) {
            var doc = Doc;
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

                        var esi = childElement.GetSchemaInfo();
                        h += esi?.SchemaType != null ? $"({esi.SchemaType.QualifiedName.Name }) " : "";

                        if (childElement.HasAttributes) {
                            foreach (var a in childElement.Attributes()) {
                                h += " " + a.Name.ToString() + "=" + a.Value.ToString();
                                var xname = a.BaseUri;
                                var si = a.GetSchemaInfo();

                                h += si?.SchemaType != null ? $"({si.SchemaType.QualifiedName.Name }) " : "";
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
        
        #endregion
    }
}
