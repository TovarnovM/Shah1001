using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Optimizer.Models {
    public class TreeNode: NotifyBase {
        private string _name;

        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<TreeNode> Childs { get; set; } = new ObservableCollection<TreeNode>();
        public ObservableCollection<NodeAttribute> Attrs { get; set; } = new ObservableCollection<NodeAttribute>();
        public TreeNode Parent { get; set; }
        public XElement Element { get; set; }
        public string Id { get; set; }

        public TreeNode(string name, TreeNode parent = null) {
            Name = name;
            Parent = parent;
            if(Parent != null) {
                parent.Childs.Add(this);
            }
        }
        
    }
}
