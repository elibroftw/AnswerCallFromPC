using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace AnswerCallFromPC
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    /// When renaming files, make sure first line in XAML reflects the change

    public partial class IncomingCallWindow : Window
    {

        SoundPlayer snd = new SoundPlayer(Properties.Resources.default_ringtone);

        public IncomingCallWindow(String CallerName)
        {
            InitializeComponent();
            Left = SystemParameters.PrimaryScreenWidth - Width;
            double ratio = SystemParameters.PrimaryScreenHeight / System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            Top = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height * ratio - Height;
            Topmost = true;
            //int TaskBarHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            Thickness margin = CallerNameTextBlock.Margin;
            if (CallerName.Count(f => f == ' ') > 1)
            {
                margin.Top = 0;
            }
            CallerNameTextBlock.Margin = margin;
            CallerNameTextBlock.Text = CallerName;
            snd.PlayLooping();  // plays audio on repeat
            // add volume options in settings
            // add that frosted glass look later
        }

        private void AcceptCall(object sender, RoutedEventArgs e)
        {
            snd.Stop();
            Window CurrentCallWindow = new CurrentCallWindow(CallerNameTextBlock.Text);
            CurrentCallWindow.Show();
            Close();
        }

        private void DeclineCall(object sender, RoutedEventArgs e)
        {
            snd.Stop();
            // Tell Android to end the call
            Close();
        }

        private void onTimeOut(object sender, RoutedEventArgs e)
        {
            snd.Stop();
        }
    }
}
