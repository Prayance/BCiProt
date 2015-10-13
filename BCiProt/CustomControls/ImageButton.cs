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
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:BCiProt"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:BCiProt;assembly=BCiProt"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ImageButton/>
    ///
    /// </summary>
    public class ImageButton : Button //sets up the inheritance from Button, so as I convert it to imagebutton
    {
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        /// <summary>
        /// For setting the image we need a property, which I named Image.
        /// But in the WPF Custom Control, we use Dependency Property. (line 77 onwards)
        /// </summary>
        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        /// <summary>
        /// I need two properties to set Image Size, for our new Control(ImageWidth and ImageHeight).
        /// </summary>
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        /// <summary>
        /// Dependency property for Image
        /// tip:
        /// The parameter which we use in the PropertyMetadata constructor. 
        /// This parameter uses Default Value for property. So for some types we need set the correct value, like Image Property.
        /// </summary>
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image",
            typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));

        /// <summary>
        /// Dependency property for Image Height 
        /// </summary>
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight",
            typeof(double), typeof(ImageButton), new PropertyMetadata(Double.NaN));

        /// <summary>
        /// Dependency property for Image Width 
        /// </summary>
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register("ImageWidth",
            typeof(double), typeof(ImageButton), new PropertyMetadata(Double.NaN));
    }
}
