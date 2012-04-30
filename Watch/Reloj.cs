using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace Watch
{
    public class Reloj : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _minute;
        private int _second;
        private int _hour;

        private DispatcherTimer _timer;
        private bool _isAnalog;
        public bool IsAnalog
        {
            get { return _isAnalog; }
            set { _isAnalog = value; UpdateWatchProperties(); }
        }

        public Reloj()
        {
            InitTimer();
        }

        //public void Init()
        //{
        //    UpdateWatchProperties();
        //}

        private void InitTimer()
        {
            _timer = new DispatcherTimer {Interval = new TimeSpan(0, 0, 0, 1)};
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        void TimerTick(object sender, EventArgs e)
        {
            UpdateWatchProperties();
        }

        private void UpdateWatchProperties()
        {
            if (IsAnalog)
            {
                UpdateAnalogWatchProperties();
            }
            else
            {
                UpdateDigitalWatchProperties();
            }
        }

        private void UpdateAnalogWatchProperties()
        {
            //Values are going to be angles for the transformation
            var currentTime = DateTime.Now;
            Hour = (int) ((((float) currentTime.Hour) / 12) * 360 + currentTime.Minute / 2);
            Minute = (int) ((((float)currentTime.Minute) / 60) * 360);
            Second = (int)((((float)currentTime.Second) / 60) * 360);
        }

        private void UpdateDigitalWatchProperties()
        {
            var currentTime = DateTime.Now;
            Hour = currentTime.Hour;
            Minute = currentTime.Minute;
            Second = currentTime.Second;
        }

        public int Minute
        {
            get { return _minute; }
            set {
                _minute = value;
                OnPropertyChanged("Minute");
            }
        }

        public int Second
        {
            get { return _second; }
            set { 
                _second = value;
                OnPropertyChanged("Second");
            }
        }

        public int Hour
        {
            get { return _hour; }
            set {
                _hour = value;
                OnPropertyChanged("Hour");
            }
        }

        // Create the OnPropertyChanged method to raise the event
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
