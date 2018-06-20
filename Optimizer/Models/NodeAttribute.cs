using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer.Models {
    public class NodeAttribute: NotifyBase {
        public Action<NodeAttribute> CheckUnCheckAction { get; set; }

        private bool _isVariate;

        public bool IsVariate {
            get { return _isVariate; }
            set {
                _isVariate = value;
                OnPropertyChanged();
                CheckUnCheckAction?.Invoke(this);
            }
        }

        public string Name { get; set; }
        public string Value { get; set; }
        public string XsdType { get; set; }
        public TreeNode Parent { get; set; }
    }
}
