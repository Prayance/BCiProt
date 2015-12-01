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

        private bool canProceed = false;
        private int counter = 0;
        private int gameOverCounter = 0;

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = false;

            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            if (checkUserInput() && counter == 0 && gameOverCounter < 2)
            {
                // TODO: The user will land on a different page depending on the user's permissions.

                // MessageBox.Show("Login is successful", "Success", MessageBoxButton.OKCancel, MessageBoxImage.Asterisk);
                // navigate to MainWindow
                MainWindow mw = new MainWindow(); //we can send more than 1 parameters here.
                // show Main form object, and hide the login form view
                mw.Show();
                this.Hide();
            }
            else if (counter == 3 && gameOverCounter < 2)
            {
                //messagebox appears
                MessageBoxResult result = MessageBox.Show("Login was not successful.", "Failed", MessageBoxButton.OKCancel, MessageBoxImage.Stop);
                counter = 0;
                gameOverCounter++;
                //if user clicks cancel
                if (result == MessageBoxResult.Cancel)
                {
                    Application.Current.Shutdown();
                }
                else //if user clicks ok
                {
                    clearFields();
                }
            }
            else if(gameOverCounter == 2)
            {
                // Lock the account and close the application
                //messagebox appears
                MessageBoxResult result = MessageBox.Show("Login was not successful. The account with username " + txtUserName.Text + 
                    ", as been locked. Please contact your administrator for more information.", "Failed", MessageBoxButton.OK, MessageBoxImage.Stop);
                counter = 0;
                gameOverCounter = 0;
                // TODO: username lock
                Application.Current.Shutdown();
            }
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

        // All the logic is here for the login
        public bool checkUserInput()
        {
            canProceed = false;
            // get the username the user entered
            string username = txtUserName.Text;
            // get the password the user entered
            string password = txtPassword.Password;

            //if they did not enter anything on username textbox
            if (username == "")
            {
                MessageBox.Show("You haven't filled out the username field.", "Please enter your credentials.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                counter++;
                return canProceed;
            }
            //if they did not enter anything on passwordbox
            else if (password == "" || password == null)
            {
                MessageBox.Show("You haven't filled out the password field.", "Please enter your credentials.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                counter++;
                return canProceed;
            }
            // if the username is not a match
            // at the moment the comparison is childish just to make sure the logic works. 
            //else if (username != "elly")
            //{
            //    MessageBox.Show("The username you have entered is not recognised.", "Please re-enter your credentials.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //    counter++;
            //    return canProceed;
            //}
            // if the password is not a match
            // QUESTION: DO I need this one?
            // at the moment the comparison is childish just to make sure the logic works. 
            //else if (password != "and" || password != "and1")
            //{
            //    MessageBox.Show("The password you have entered is not recognised.", "Please re-enter your credentials.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //    counter++;
            //    return canProceed;
            //}
            // if the combination of the username and password is wrong:
            else if ((password == "and" && username != "elly") || (password != "and" && username == "elly"))
            {
                MessageBox.Show("The combination of username and  password you have entered is not correct.", "Please re-enter your credentials.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                counter++;
                return canProceed;
            }
            else
            {
                canProceed = true;
                counter = 0;
                return canProceed;
            }
        }
    }
}
