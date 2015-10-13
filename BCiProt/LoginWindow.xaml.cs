using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace BCiProt
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = false;

            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Write code here to authenticate user
            // If authenticated, then set DialogResult=true

            // If login successful go to mainWindow.
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }

        /// <summary>
        /// It clears all the texfields of the login form
        /// </summary>
        private void clearFields()
        {
            txtUserName.Text = "";
            txtPassword.Clear();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

        private void DetailsText_Loaded(object sender, RoutedEventArgs e)
        {
            DetailsText.Text = "This is some longer text in the TextBlock. " +
            "It should have the introduction of the transcoder details. " +
            "TextBlock is meant for longer text, as long as we need";
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
