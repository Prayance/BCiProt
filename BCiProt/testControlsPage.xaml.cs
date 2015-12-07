using BCiProt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BCiProt
{
    /// <summary>
    /// Interaction logic for testControlsPage.xaml
    /// </summary>
    public partial class testControlsPage : Page
    {
        public testControlsPage()
        {
            InitializeComponent();
            List<Realm> popupItems = new List<Realm>();
            popupItems.Add(new Realm() { rName = "realm 1", pictureSource = "/Images/AudioTreeViewImages/green_dot.png" });
            popupItems.Add(new Realm() { rName = "realm 2", pictureSource = "/Images/AudioTreeViewImages/green_dot.png" });
            popupItems.Add(new Realm() { rName = "realm 3", pictureSource = "/Images/AudioTreeViewImages/red_dot.png" });
            realms.ItemsSource = popupItems;
        }

        private void lbTodoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (realms.SelectedItem != null)
                this.Title = (realms.SelectedItem as Realm).rName;
        }

        private void OKbtn_Click(object sender, RoutedEventArgs e)
        {
            foreach (object o in realms.SelectedItems)
                MessageBox.Show((o as Realm).rName);
        }

        private void newRealm_Click(object sender, RoutedEventArgs e)
        {
            //navigate to the create realm page.
        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            //close the popup
        }
    }
}
