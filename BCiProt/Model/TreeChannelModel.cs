using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCiProt.Model
{
    public class TreeChannelModel : TreeViewItemBase
    {
        public TreeChannelModel()
        {
            this.BasicNodes = new ObservableCollection<ChannelBasicType>();
            //this.ExtraNodes = new ObservableCollection<ChannelExtraType>();
        }

        public string Name { get; set; }
        public string Mode { get; set; }
        public ObservableCollection<ChannelBasicType> BasicNodes { get; set; }
        //public ObservableCollection<ChannelExtraType> ExtraNodes { get; set; }

        /// <summary>
        /// If the mode is AC3 then the string will have AC3 
        /// otherwise the string will have the NAME of the other mode.
        /// </summary>
        /// <returns>The Type of the Mode AC3 or other.</returns>
        public string getModeType()
        {
            if (Mode == "AC3")
            {
                return "AC3";
            }
            return "Other";
        }
    }

    public class ChannelBasicType
    {
        public string basicType { get; set; }
        public string basicValue { get; set; }
        public string imageSource { get; set; }
        public bool isBasic { get; set; } // if it is basic = true, else it is AC3 property.
    }

    // Question: Do I even need the ChannelExtraType class?
    //public class ChannelExtraType
    //{
    //    public string extraType { get; set; }
    //    public string extraValue { get; set; }
    //}
}
