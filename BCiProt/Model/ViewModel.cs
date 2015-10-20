using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BCiProt.Model
{
    public class ViewModel : ViewModelBase
    {

        private Dictionary<string, object> _items;
        private Dictionary<string, object> _selectedItems;


        public Dictionary<string, object> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                NotifyPropertyChanged("Items");
            }
        }

        public Dictionary<string, object> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            set
            {
                _selectedItems = value;
                NotifyPropertyChanged("SelectedItems");
            }
        }



        public ViewModel()
        {
            Items = new Dictionary<string, object>();
            Items.Add("Front Left", "FL");
            Items.Add("Front Right", "FR");
            Items.Add("Front Centre", "FC");
            Items.Add("Low Frequency Effects (Sub Woofer)", "LFE");
            Items.Add("Back Left", "BL");
            Items.Add("Back Right", "BR");
            Items.Add("Front Left Centre", "FLC");
            Items.Add("Front Right Centre", "FRC");
            Items.Add("Back Centre", "BC");
            Items.Add("Side Left", "SL");
            Items.Add("Side Right", "SR");

            SelectedItems = new Dictionary<string, object>();
            SelectedItems.Add("Back Left", "BL");
            SelectedItems.Add("Back Right", "BR");

        }

        /// <summary>
        ///  This method needs to be modified. it can return the keys of the selected items for the database.
        /// </summary>
        private void Submit()
        {
            foreach (KeyValuePair<string, object> s in SelectedItems)
                MessageBox.Show(s.Key);
        }


        /// <summary>
        /// modified version of the above. 
        /// </summary>
        /// <returns></returns>
        public List<string> getKey()
        {
            List<string> myKeys = new List<string>();
            foreach (KeyValuePair<string, object> s in SelectedItems)
            {
                myKeys.Add(s.Value.ToString());
            }
            return myKeys;
        }

    }
}
