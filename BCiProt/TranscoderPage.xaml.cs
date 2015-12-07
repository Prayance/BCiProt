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
    /// Interaction logic for TranscoderPage.xaml
    /// </summary>
    public partial class TranscoderPage : Page
    {
        List<Realm> popupItems = new List<Realm>();

        public TranscoderPage()
        {
            InitializeComponent();
            this.ShowsNavigationUI = false;
            // the realm popup from the transcoder page.
            populateRealms();
            realms.ItemsSource = popupItems;
        }

        /// <summary>
        /// if the auto-realm is enabled, the transcoder will go and allocate itself to a random realm.
        /// The realmChoiceButton is not enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoRealm_Checked(object sender, RoutedEventArgs e)
        {
            realmChoiceButton.IsEnabled = false;
            myRealChoice.IsOpen = false;
        }

        /// <summary>
        /// If the auto-realm is not enabled then the user has to choose a realm to alocate the transcoder. 
        /// The realmChoiceButton is enabled.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void autoRealm_Unchecked(object sender, RoutedEventArgs e)
        {
            realmChoiceButton.IsEnabled = true;
        }

        private void realmChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            myRealChoice.IsOpen = true;
        }

        private void populateRealms()
        {
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
            NavigationService.Navigate(new Uri("RealmPage.xaml", UriKind.Relative));
        }

        private void cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            //close the popup
            myRealChoice.IsOpen = false;
        }
    }
}