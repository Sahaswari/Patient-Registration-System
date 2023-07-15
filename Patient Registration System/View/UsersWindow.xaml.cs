using Patient_Registration_System.Model;
using Patient_Registration_System.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace Patient_Registration_System.View
{
    /// <summary>
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : UserControl
    {
        public ObservableCollection<User> users;
        private User userselectedItem;
        private int userId;
        public UsersWindow()
        {
            InitializeComponent();
            users = new ObservableCollection<User>(UserData.GetUserFromDB());
            lstvuser.ItemsSource = users;
            userselectedItem = null;

            string[] comboItemtype = new[] { "admin", "normal" };
            cmbusertype.ItemsSource = comboItemtype;
        }

        private void btnuseradd_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txbuserid.Text) || string.IsNullOrEmpty(txbusername.Text) || string.IsNullOrEmpty(txbuserpassword.Text) 
                || string.IsNullOrEmpty(txbuserfullname.Text) || string.IsNullOrEmpty(txbuserage.Text) || string.IsNullOrEmpty(txbusercontactnumber.Text)
                ||string.IsNullOrEmpty(cmbusertype.Text))
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }
            User user = new User
            {
                UserId = int.Parse(txbuserid.Text),
                UserName = txbusername.Text,
                UserPassword = txbuserpassword.Text,
                UserFullName = txbuserfullname.Text,
                UserAge = int.Parse(txbuserage.Text),
                UserContactNumber = txbusercontactnumber.Text,
                UserType = cmbusertype.Text

            };
            MessageBox.Show("Succesfully Added.");

            txbuserid.Text = null;
            txbusername.Text = null;
            txbuserpassword.Text = null;
            txbuserfullname.Text = null;
            txbuserage.Text = null;
            txbusercontactnumber.Text = null;
            cmbusertype.SelectedIndex = 0;
           

            users.Add(user);
            lstvuser.ItemsSource = users;

            UserData.AddUserToDB(user);
        }

        private void lstvuser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            userselectedItem = (User)lstvuser.SelectedItem;
        }

        private void useredit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Follow the Below Steps.\n  1) Please Update the Data.\n  2) Then Select Data Again. \n  3) Then Press Update Button.");

            Button? b = sender as Button;

            User? user = b?.CommandParameter as User;

            txbuserid.Text = user?.UserId.ToString();
            txbusername.Text = user?.UserName;
            txbuserpassword.Text = user?.UserPassword;
            txbuserfullname.Text = user?.UserFullName;
            txbuserage.Text = user?.UserAge.ToString();
            txbusercontactnumber.Text = user?.UserContactNumber;
            cmbusertype.Text = user?.UserType;

            userId = user.UserId;
        }

        private void btnuserupdate_Click(object sender, RoutedEventArgs e)
        {
            if (userselectedItem != null)
            {

                UserData.UpdateUserToDB(userId, txbusername.Text, txbuserpassword.Text, txbuserfullname.Text, txbuserage.Text, txbusercontactnumber.Text,cmbusertype.Text);

                MessageBox.Show("DataBase Is Succesfully Updated. Later Data Will Show.");

                txbuserid.Text = null;
                txbusername.Text = null;
                txbuserpassword.Text = null;
                txbuserfullname.Text = null;
                txbuserage.Text = null;
                txbusercontactnumber.Text = null;
                cmbusertype.Text = null;

                lstvuser.ItemsSource = users;

            }

            else
            {
                MessageBox.Show("Please Select Data.");
            }
        }

        private void btnuserdelete_Click(object sender, RoutedEventArgs e)
        {
            if (userselectedItem != null)
            {
                UserData.DeleteUserFromDB(userselectedItem.UserId);
                System.Windows.MessageBox.Show("Your Selected Data is Deleted Successfully. Later Data Will Show.");
            }
            else
            {
                MessageBox.Show("Please Select Data.");
            }
        }
    }
}
