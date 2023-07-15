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
    /// Interaction logic for OthersWindow.xaml
    /// </summary>
    public partial class OthersWindow : UserControl
    {
        public ObservableCollection<Other> others;
        private Other otherselectedItem;
        private int otherId;
        public OthersWindow()
        {
            InitializeComponent();
            others = new ObservableCollection<Other>(OtherData.GetOtherFromDB());
            lstvother.ItemsSource = others;
            otherselectedItem = null;
        }

        private void btnotheradd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbotherid.Text) || string.IsNullOrEmpty(txbothername.Text) ||
             string.IsNullOrEmpty(txbotherchargingrate.Text))
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }


            Other other = new Other
            {
                OtherId = int.Parse(txbotherid.Text),
                OtherName = txbothername.Text,
                OtherChargingRate = double.Parse(txbotherchargingrate.Text)

            };

            System.Windows.MessageBox.Show("Succesfully Added.");

            txbotherid.Text = null;
            txbothername.Text = null;
            txbotherchargingrate.Text = null;

            others.Add(other);
            lstvother.ItemsSource = others;

            OtherData.AddOtherToDB(other);
        }

        private void lstvother_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            otherselectedItem = (Other)lstvother.SelectedItem;
        }

        private void otheredit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Follow the Below Steps.\n  1) Please Update the Data.\n  2) Then Select Data Again. \n  3) Then Press Update Button.");


            Button? b = sender as Button;

            Other? other = b?.CommandParameter as Other;

            txbotherid.Text = other?.OtherId.ToString();
            txbothername.Text = other?.OtherName;
            txbotherchargingrate.Text = other?.OtherChargingRate.ToString();

            otherId = other.OtherId;
        }

        private void btnotherupdate_Click(object sender, RoutedEventArgs e)
        {
            if (otherselectedItem != null)
            {

                OtherData.UpdateOtherToDB(otherId, txbothername.Text, txbotherchargingrate.Text);

                System.Windows.MessageBox.Show("DataBase Is Succesfully Updated. Later Data Will Show.");
                txbotherid.Text = null;
                txbothername.Text = null;
                txbotherchargingrate.Text = null;

                lstvother.ItemsSource = others;
            }
            else 
            {
                MessageBox.Show("Please Select Data.");
            }
        }

        private void btnotherdelete_Click(object sender, RoutedEventArgs e)
        {
            if (otherselectedItem != null)
            {
                OtherData.DeleteOtherFromDB(otherselectedItem.OtherId);
                System.Windows.MessageBox.Show("Your Selected Data is Deleted Successfully. Later Data Will Show.");
            }
            else
            {
                MessageBox.Show("Please Select Data.");
            }
            
            
        }
    }
}
