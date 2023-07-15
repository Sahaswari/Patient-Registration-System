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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd,int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle,161,2,0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState==WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState=WindowState.Normal;
        }

        private void rbtnHome_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new HomeWindow();
        }

        private void rbtnUsers_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UsersWindow();
        }

        private void rbtnPatients_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new PatientsWindow();
        }

        private void rbtnDoctors_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new DoctorsWindow();
        }

        private void rbtnTests_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new TestsWindow();
        }

        private void rbtnOthers_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new OthersWindow();
        }
    }
}
