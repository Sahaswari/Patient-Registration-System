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
    /// Interaction logic for DoctorsWindow.xaml
    /// </summary>
    public partial class DoctorsWindow : UserControl
    {
        public ObservableCollection<Doctor>doctors;
        private Doctor selectedItem;
        private int doctorId;
        public DoctorsWindow()
        {
            InitializeComponent();

            // string[] comboItems = new[] {"Eye","Head","Ear","Cardiac"};
            // txbspecilization.ItemsSource=comboItems;
            selectedItem = null;
            doctors = new ObservableCollection<Doctor>(DoctorData.GetDoctorFromDB());

        


            lstvdoctor.ItemsSource = doctors;
        }

        private void btndoctoradd_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txbid.Text) || string.IsNullOrEmpty(txbname.Text) ||
                string.IsNullOrEmpty(txbage.Text) || string.IsNullOrEmpty(txbcontactnumber.Text) ||
                string.IsNullOrEmpty(txbmoregistrationno.Text) || string.IsNullOrEmpty(txbspecilization.Text) ||
                string.IsNullOrEmpty(txbchargingrate.Text))
            {
                MessageBox.Show("Please fill all the fields.");
                return; 
            }

            Doctor doctor = new Doctor

            {
                    DoctorId = int.Parse(txbid.Text),
                    DoctorName = txbname.Text,
                    DoctorAge = int.Parse(txbage.Text),
                    ContactNumber = txbcontactnumber.Text,
                    MORegistrationNo = txbmoregistrationno.Text,
                    Specilization = txbspecilization.Text,
                    ChargingRate = double.Parse(txbchargingrate.Text)

            };

                
            {
                    MessageBox.Show("Succesfully Added.");


                    txbid.Text = null;
                    txbname.Text = null;
                    txbage.Text = null;
                    txbcontactnumber.Text = null;
                    txbmoregistrationno.Text = null;
                    txbspecilization.Text = null;
                    txbchargingrate.Text = null;

                    doctors.Add(doctor);
                    lstvdoctor.ItemsSource = doctors;

                    DoctorData.AddDoctorToDB(doctor);
            }

              
            
        }

        private void lstvdoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = (Doctor)lstvdoctor.SelectedItem;
        }

        private void doctoredit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Follow the Below Steps.\n  1) Please Update the Data.\n  2) Then Select Data Again. \n  3) Then Press Update Button.");

            Button? b = sender as Button;

            Doctor? doctor = b?.CommandParameter as Doctor;

            txbid.Text = doctor?.DoctorId.ToString();
            txbname.Text = doctor?.DoctorName;
            txbage.Text = doctor?.DoctorAge.ToString();
            txbcontactnumber.Text = doctor?.ContactNumber;
            txbmoregistrationno.Text = doctor?.MORegistrationNo;
            txbspecilization.Text = doctor?.Specilization.ToString();
            txbchargingrate.Text = doctor?.ChargingRate.ToString();

            doctorId = doctor.DoctorId;
        }

        /*private void txbspecilization_SelectionChanged(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(txbspecilization.SelectedItem.ToString());
        }
        */
        private void btndoctorupdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItem != null)
            {

                DoctorData.UpdateDoctorToDB(doctorId, txbname.Text, txbage.Text, txbcontactnumber.Text, txbmoregistrationno.Text,
                    txbspecilization.Text, txbchargingrate.Text);

                MessageBox.Show("DataBase Is Succesfully Updated. Later Data Will Show.");
                txbid.Text = null;
                txbname.Text = null;
                txbage.Text = null;
                txbcontactnumber.Text = null;
                txbmoregistrationno.Text = null;
                txbspecilization.Text = null;
                txbchargingrate.Text = null;

                lstvdoctor.ItemsSource = doctors;
            }
            else
            {
                MessageBox.Show("Please Select Data.");
            }
        }

        private void btndoctordelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItem != null)
            {
                DoctorData.DeleteDoctorFromDB(selectedItem.DoctorId);
                System.Windows.MessageBox.Show("Your Selected Data is Deleted Successfully. Later Data Will Show.");
            }
            else
            {
                MessageBox.Show("Please Select Data.");
            }
        }
    }
}
