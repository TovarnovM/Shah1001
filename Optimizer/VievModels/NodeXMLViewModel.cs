using Optimizer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer.VievModels {
    public class NodeXMLViewModel: NotifyBase {
        public TreeNode Node { get; }
        public ReadOnlyCollection<NodeXMLViewModel> Children { get; }
        public ObservableCollection<NodeAttribute> Attributes { get; }
        public NodeXMLViewModel Parent { get; }
        private bool _isExpand = true;

        public bool IsExpanded {
            get { return _isExpand; }
            set {
                _isExpand = value;
                OnPropertyChanged();
            }
        }


        #region Constructors

        public NodeXMLViewModel(TreeNode person)
            : this(person, null) {
        }

        private NodeXMLViewModel(TreeNode node, NodeXMLViewModel parent) {
            Node = node;
            Parent = parent;

            Children = new ReadOnlyCollection<NodeXMLViewModel>(
                    (from child in Node.Childs
                     select new NodeXMLViewModel(child, this))
                     .ToList());

            Attributes = node.Attrs;
        }

        #endregion // Constructors

        public string Name {
            get { return Node.Name; }
            set {
                Node.Name = value;
                OnPropertyChanged();
            }
        }

    }
}
