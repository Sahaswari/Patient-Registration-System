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
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace Patient_Registration_System.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlnControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlnControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void rbtnNRegistration_Checked(object sender, RoutedEventArgs e)
        {
            CCN.Content = new NRegistrationWindow();
        }

        private void rbtnNUpdate_Checked(object sender, RoutedEventArgs e)
        {
            CCN.Content = new NUpdateWindow();
        }

        private void rbtnNDelete_Checked(object sender, RoutedEventArgs e)
        {
            CCN.Content = new NDeleteWindow();
        }

        private void rbtnNPayements_Checked(object sender, RoutedEventArgs e)
        {
            CCN.Content = new NPayementsWindow();
        }

        private void rbtnNHome_Checked(object sender, RoutedEventArgs e)
        {
            CCN.Content = new NHomeWindow();
        }
    }
}
