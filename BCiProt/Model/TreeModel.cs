using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCiProt.Model
{
    /// <summary>
    /// This tree model is for the Data profile
    /// </summary>
    public class TreeModel
    {
        public TreeModel()
        {
            this.Nodes = new ObservableCollection<TreeNode>();
        }


        public string Type { get; set; }

        public ObservableCollection<TreeNode> Nodes { get; set; }
    }

    public class TreeNode
    {
        public string controlType { get; set; }
        public string controlValue { get; set; }
    }


    public class Subtitle
    {
        public string codec { get; set; }
        public string encodec { get; set; }
        public string language { get; set; }
    }
}
