using BCiProt.SettingsManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // These will help us keep track of which column we're currently sorting by and the adorner we placed to indicate it.
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;

        public MainWindow()
        {
            InitializeComponent();
            List<myTranscoder> items = new List<myTranscoder>();
            items.Add(new myTranscoder() { Transcoder = "John's Transcoder", NumberOfTasks = 5, TaskType = "Transcoding", currentState = OnOff.ON });
            items.Add(new myTranscoder() { Transcoder = "Elly's Transcoder", NumberOfTasks = 9, TaskType = "Test", currentState = OnOff.OFF });
            items.Add(new myTranscoder() { Transcoder = "Tom's Transcoder", NumberOfTasks = 1, TaskType = "Transcoding", currentState = OnOff.ON });
            items.Add(new myTranscoder() { Transcoder = "Geoff's Transcoder", NumberOfTasks = 13, TaskType = "Test", currentState = OnOff.OFF });
            items.Add(new myTranscoder() { Transcoder = "Mark's Transcoder", NumberOfTasks = 13, TaskType = "Test", currentState = OnOff.OFF });
            lvUsers.ItemsSource = items;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvUsers.ItemsSource);
            view.Filter = UserFilter;


            List<Event> eventLog = new List<Event>();
            eventLog.Add(new Event() { EventName = "Success", Happened = "Monday 13:00", EventNote = "comment 1" });
            eventLog.Add(new Event() { EventName = "Success", Happened = "Tuesday 09:00", EventNote = "my notes" });
            eventLog.Add(new Event() { EventName = "Failed", Happened = "Tuesday 15:00", EventNote = "notes 2" });
            lvDataBinding.ItemsSource = eventLog;

            #region // User settings for resize
            var userPrefs = new UserPreferences();

            this.Height = userPrefs.WindowHeight;
            this.Width = userPrefs.WindowWidth;
            this.Top = userPrefs.WindowTop;
            this.Left = userPrefs.WindowLeft;
            this.WindowState = userPrefs.WindowState;
            #endregion
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as myTranscoder).Transcoder.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvUsers.ItemsSource).Refresh();
        }

        /// <summary>
        /// In the lvUsersColumnHeader_Click event handler, we start off by getting a reference to the column that the user clicked. 
        /// With this, we can decide which property on the myTranscoder class to sort by, simply by looking at the Tag property that
        ///  we defined in XAML. We then check if we're already sorting by a column - if that is the case, we remove the adorner 
        /// and clear the current sort descriptions. 
        /// 
        /// After that, we're ready to decide the direction. The default is ascending, but we do a check to see if we're already
        ///  sorting by the column that the user clicked - if that is the case, we change the direction to descending. 
        /// 
        /// In the end, we create a new SortAdorner, passing in the column that it should be rendered on, as well as the direction.
        /// We add this to the AdornerLayer of the column header, and at the very end, we add a SortDescription to the ListView,
        /// to let it know which property to sort by and in which direction.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvUsersColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                lvUsers.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            lvUsers.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        /// <summary>
        /// Verifies that the user wants to close the window/ program
        /// AND
        /// Save the settings when the window is closing 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            // if the user clicks the window close x button:
            if (MessageBox.Show("Are you sure that you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Application.Current.Shutdown();

            #region // Save the user settings for resize
            var userPrefs = new UserPreferences();

            userPrefs.WindowHeight = this.Height;
            userPrefs.WindowWidth = this.Width;
            userPrefs.WindowTop = this.Top;
            userPrefs.WindowLeft = this.Left;
            userPrefs.WindowState = this.WindowState;

            userPrefs.Save();
            #endregion
        }

        private void GraphButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("It will go to the graphs page. Maybe we need to buy a graph toolkit.");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            #region // User settings for resize
            var userPrefs = new UserPreferences();

            this.Height = userPrefs.WindowHeight;
            this.Width = userPrefs.WindowWidth;
            this.Top = userPrefs.WindowTop;
            this.Left = userPrefs.WindowLeft;
            this.WindowState = userPrefs.WindowState;
            #endregion

            // if the user clicks the window close x button:
            if (MessageBox.Show("Are you sure that you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            #region // User settings for resize
            var userPrefs = new UserPreferences();

            this.Height = userPrefs.WindowHeight;
            this.Width = userPrefs.WindowWidth;
            this.Top = userPrefs.WindowTop;
            this.Left = userPrefs.WindowLeft;
            this.WindowState = userPrefs.WindowState;
            #endregion

            // if the user clicks the window close x button:
            if (MessageBox.Show("Are you sure that you want to logout?", "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                LoginWindow lw = new LoginWindow();
                lw.Show();
                this.Hide(); // do not forget to reset this page before hide.
            }
        }

        private void TransCreate_Click(object sender, RoutedEventArgs e)
        { 
            this.Hide();
            MainTab tt = new MainTab(this);
            tt.Show();
        }

        /// <summary>
        /// Takes you to the profile tab.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateProfile_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ProfileTab pt = new ProfileTab(this);
            pt.Show();
        }
    }

    public enum OnOff { ON, OFF };

    /// <summary>
    /// The myTranscoder class is just a basic information class, used to contain information about a user. 
    /// Some of this information is used in the UI layer, where we bind to the Transcoder, NumberOfTasks and currentState properties.
    /// </summary>
    public class myTranscoder
    {
        public string Transcoder { get; set; }

        public int NumberOfTasks { get; set; }

        public string TaskType { get; set; }

        public OnOff currentState { get; set; }
    }

    public class Event
    {
        public string EventName { get; set; }

        public string Happened { get; set; }

        public string EventNote { get; set; }
    }

    public class SortAdorner : Adorner
    {
        private static Geometry ascGeometry =
                Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

        private static Geometry descGeometry =
                Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

        public ListSortDirection Direction { get; private set; }

        /// <summary>
        /// All this little class does is to draw a triangle, either pointing up or down, depending on the sort direction. 
        /// WPF uses the concept of adorners to allow you to paint stuff over other controls, and this is exactly what 
        /// we want here: The ability to draw a sorting triangle on top of our ListView column header.
        /// 
        /// The SortAdorner works by defining two Geometry objects, which are basically used to describe 2D shapes - in
        ///  this case a triangle with the tip pointing up and one with the tip pointing down. The Geometry.Parse() method
        /// uses the list of points to draw the triangles, which will be explained more thoroughly in a later article. 
        /// 
        /// The SortAdorner is aware of the sort direction, because it needs to draw the proper triangle, but is not aware 
        /// of the field that we order by - this is handled in the UI layer.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="dir"></param>
        public SortAdorner(UIElement element, ListSortDirection dir)
                : base(element)
        {
            this.Direction = dir;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (AdornedElement.RenderSize.Width < 20)
                return;

            TranslateTransform transform = new TranslateTransform
                    (
                            AdornedElement.RenderSize.Width - 15,
                            (AdornedElement.RenderSize.Height - 5) / 2
                    );
            drawingContext.PushTransform(transform);

            Geometry geometry = ascGeometry;
            if (this.Direction == ListSortDirection.Descending)
                geometry = descGeometry;
            drawingContext.DrawGeometry(Brushes.Black, null, geometry);

            drawingContext.Pop();
        }
    }
}