using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xml_tst.DataRepresent {
    public class TreeNode {
        public string Name { get; set; }
        public List<TreeNode> Childs { get; set; } = new List<TreeNode>();
        public TreeNode Parent { get; set; }
        public TreeNode(string name, TreeNode parent = null) {
            Name = name;
            Parent = parent;
        }
    }
}
