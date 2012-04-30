using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace Watch
{
    public partial class MainPage : PhoneApplicationPage
    {
        private readonly Reloj _reloj;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            _reloj = new Reloj();
            Loaded += MainPageLoaded;
        }

        private void SetWatchType()
        {
            var settingsBrain = new SettingsBrain();
            _reloj.IsAnalog = settingsBrain.Read();
        }

        void MainPageLoaded(object sender, RoutedEventArgs e)
        {
            SetWatchType();
            LayoutRoot.Children.Clear();
            UserControl userControl;
            if (_reloj.IsAnalog)
            {
                userControl = new Analog();
      
            }
            else
            {
                userControl = new Digital();
            }
            LayoutRoot.Children.Add(userControl); 
        }

        private void ApplicationBarIconButtonClick(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Settings.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}