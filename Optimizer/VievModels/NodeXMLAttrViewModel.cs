using Optimizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer.VievModels {
    public class NodeXMLAttrViewModel: NotifyBase {
        public NodeAttribute Attribute { get; }
        public NodeXMLViewModel Parent { get; }
        public NodeXMLAttrViewModel(NodeAttribute attribute, NodeXMLViewModel parent) {
            Attribute = attribute;
            Parent = parent;
        }

        
        public bool IsVariate {
            get { return Attribute.IsVariate; }
            set {
                Attribute.IsVariate = value;
                OnPropertyChanged();
            }
        }

        public string Name {
            get { return Attribute.Name; }
            set {
                Attribute.Name = value;
                OnPropertyChanged();
            }
        }

        public string XSDType {
            get { return Attribute.XsdType; }
            set {
                Attribute.XsdType = value;
                OnPropertyChanged();
            }
        }

        public string Value {
            get { return Attribute.Value; }
            set {
                Attribute.Value = value;
                OnPropertyChanged();
            }
        }
    }
}
