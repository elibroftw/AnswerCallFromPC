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
using System.Windows.Shapes;

namespace AnswerCallFromPC
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CurrentCallWindow : Window
    {
        public CurrentCallWindow(String CallerName)
        {
            InitializeComponent();
            Left = SystemParameters.PrimaryScreenWidth - Width;
            double ratio = SystemParameters.PrimaryScreenHeight / System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            Top = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height * ratio - Height;
            Topmost = true;
            Thickness margin = CallerNameTextBlock.Margin;
            if (CallerName.Count(f => f == ' ') > 1)
            {
                margin.Bottom = 0;
                margin.Top = 0;
            }
            CallerNameTextBlock.Margin = margin;
            CallerNameTextBlock.Text = CallerName;
            // Connect Mic and transmit audio like that
        }

        private void EndCall(object sender, RoutedEventArgs e)
        {
            // Stop the call
            // Stop sending mic data
            Close();
        }
    }
}
