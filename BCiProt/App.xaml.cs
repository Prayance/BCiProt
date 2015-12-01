using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BCiProt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const int MINIMUM_SPLASH_TIME = 1500; // Miliseconds
        private const int SPLASH_FADE_TIME = 500;     // Miliseconds

        /// <summary>
        /// It loads the splash screen
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // Step 1 - Load the splash screen
            SplashScreen splash = new SplashScreen("Images/transcoderLogo.png");
            splash.Show(false, true);

            // Step 2 - Start a stop watch
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Step 3 - Load your LoginWindow but don't show it yet
            base.OnStartup(e);
            LoginWindow main = new LoginWindow();

            // Step 4 - Make sure that the splash screen lasts at least two seconds
            timer.Stop();
            int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
            if (remainingTimeToShowSplash > 0)
                Thread.Sleep(remainingTimeToShowSplash);

            // Step 5 - show the page
            splash.Close(TimeSpan.FromMilliseconds(SPLASH_FADE_TIME));
            main.Show();
        }

        /// <summary>
        /// Navigates to the help page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpBut_Click(object sender, RoutedEventArgs e)
        {
            HelpPage hp = new HelpPage();
            hp.Show();
        }

        /// <summary>
        /// This is the extended menu c# code. to make the drop down box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            var addButton = sender as FrameworkElement;
            if (addButton != null)
            {
                addButton.ContextMenu.IsOpen = true;
            }
        }

        /// <summary>
        /// To be implemented
        /// At the moment only the general profile is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveASXml_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked the save as xml button");
            //getGeneralProfileData();
            //intoGeneralTree();
            //XMLWrite.WriteToXML(gtm);
        }

        /// <summary>
        /// To be implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearMe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked the clear me button");
        }

        /// <summary>
        /// To be implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetMe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked the reset button");
            // do different things per tab
            // clear my tree
        }

        /// <summary>
        /// Load a saved profile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadSaved_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Saved Profile Location";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // TODO: openFileDialog.Filter = maybe extensions? or? 
            if (openFileDialog.ShowDialog() == true)
            {
                MessageBox.Show("Well read the xml and load it TODO.");
            }
        }

        /// <summary>
        /// to be implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTranscoder_Click(object sender, RoutedEventArgs e)
        {
            Page1 p1 = new Page1();
            ContainerWindow cw = new ContainerWindow();
            cw.myframe.NavigationService.Navigate(p1);
        }

        /// <summary>
        /// to be implemented
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDataProfile_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
