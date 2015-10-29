using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCiProt.Model
{
    /// <summary>
    /// This tree model is for the Data profile
    /// </summary>
    public class TreeModel : TreeViewItemBase
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
        public string fullFileLocation { get; set; } // this property is used on the export and import functions only.
    }


    public class TreeViewItemBase : INotifyPropertyChanged
    {
        private bool isSelected;
        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                if (value != this.isSelected)
                {
                    this.isSelected = value;
                    NotifyPropertyChanged("IsSelected");
                }
            }
        }

        private bool isExpanded;
        public bool IsExpanded
        {
            get { return this.isExpanded; }
            set
            {
                if (value != this.isExpanded)
                {
                    this.isExpanded = value;
                    NotifyPropertyChanged("IsExpanded");
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
