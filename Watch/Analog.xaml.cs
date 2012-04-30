using System.Windows;
using System.Windows.Controls;

namespace Watch
{
	public partial class Analog : UserControl
	{
		public Analog()
		{
			// Required to initialize variables
			InitializeComponent();
            //Loaded += AnalogLoaded;
		}

        //void AnalogLoaded(object sender, RoutedEventArgs e)
        //{
        //    //We begin the rotation animation of each hour, minute and second element
        //    //all the transformation info is in XAML
        //    //clockStoryboard.Begin();
        //}
	}
}