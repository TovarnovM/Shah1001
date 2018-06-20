using Optimizer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer.VievModels {
    public class TreeXMLViewModel {
        public ReadOnlyCollection<NodeXMLViewModel> Nodes { get; }
        public TreeXMLViewModel(TreeNode root) {
            var rootVM = new NodeXMLViewModel(root);
            Nodes = new ReadOnlyCollection<NodeXMLViewModel>(
                new NodeXMLViewModel[] {
                    rootVM
                });
        }
    }
}
