using Optimizer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimizer.VievModels {
    public class VariateListViewModel:NotifyBase {
        public ObservableCollection<NodeAttribute> VariableAttrs { get; }
        public ObservableCollection<string> Items{ get; set; }
        public VariateListViewModel(ObservableCollection<NodeAttribute> variableAttrs) {
            Items = new ObservableCollection<string>();
            VariableAttrs = variableAttrs;
        }
        private void YourCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args) {

        }
        string NodeAttrToStr(NodeAttribute attr) {
            return attr.Name;
        }
    }
}
