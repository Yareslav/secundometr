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
using System.Timers;


namespace laba2
{
    public partial class MainWindow : Window
    {
        int seconds = 0;
        int minutes = 0;
        int hours = 0;
        Timer timer=new Timer();
        delegate void Reseter();
        event Reseter Reset;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Elapsed += TimeProcess;
            Reset += ()=> {
                seconds = 0;
                minutes = 0;
                hours = 0;
                TimeBox.Text = "00:00:00";
            };
        }
        private void Start_CLick(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
        private void Stop_CLick(object sender, RoutedEventArgs e)
        {
            Reset();
            timer.Stop();
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            Reset();
            timer.Start();
        }
        private void TimeProcess(Object source, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                seconds++;
                if (seconds == 60)
                {
                    seconds = 0;
                    minutes++;
                }
                if (minutes == 60)
                {
                    minutes = 0;
                    hours++;
                }
                TimeBox.Text = $"{Format(hours)}:{Format(minutes)}:{Format(seconds)}";
            });
        }
        private string Format(int value)
        {
            if (value > 9) return value + "";
            return "0" + value;
        }
    }
}
