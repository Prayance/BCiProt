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
    /// Interaction logic for TranscoderTab.xaml
    /// </summary>
    public partial class MainTab : Window
    {
        private MainWindow mainWindow;
        List<Realm> popupItems = new List<Realm>();

        public MainTab(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            locationTextBlock.Text = this.Title;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                mainWindow.Show();
            }
            catch (InvalidOperationException exc)
            {
                Console.WriteLine("Had an InvalidOperationException: " + exc.Message);
            }
        }

        private void helpBut_Click(object sender, RoutedEventArgs e)
        {
            HelpPage hp = new HelpPage();
            hp.Show();
            this.Hide();
        }

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            var addButton = sender as FrameworkElement;
            if (addButton != null)
            {
                addButton.ContextMenu.IsOpen = true;
            }
        }
    }
}
