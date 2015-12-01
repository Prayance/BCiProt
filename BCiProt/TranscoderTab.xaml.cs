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
    public partial class TranscoderTab : Window
    {
        private MainWindow mainWindow;

        public TranscoderTab(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
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
    }
}
