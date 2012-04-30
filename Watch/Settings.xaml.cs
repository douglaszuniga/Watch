using System;
using Microsoft.Phone.Controls;

namespace Watch
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
            Loaded += SettingsLoaded;
        }

        void SettingsLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var settingsBrain = new SettingsBrain();
            var isAnalogChecked = settingsBrain.Read();
            rbAnalog.IsChecked = isAnalogChecked;
            rbDigital.IsChecked = !isAnalogChecked;
        }

        private void ApplicationBarIconButtonClick(object sender, EventArgs e)
        {
            //Save to virtual file config
            var settingsBrain = new SettingsBrain();
            settingsBrain.Save(rbAnalog.IsChecked != null && rbAnalog.IsChecked.Value);
            //Go Back to main
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }
    }
}