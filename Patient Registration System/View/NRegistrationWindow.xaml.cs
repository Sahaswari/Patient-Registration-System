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
    /// Interaction logic for NRegistrationWindow.xaml
    /// </summary>
    public partial class NRegistrationWindow : UserControl
    {
        //public ObservableCollection<Patient> patients;
        //private Patient selectedItem;
        private int patientId;
        public NRegistrationWindow()
        {
            InitializeComponent();

            string[] comboItemGen = new[] { "Male" , "Female" };
            txtpatientgen.ItemsSource = comboItemGen;

            string[] comboItemBlood = new[] { "O+","O-","A+","A-","B+","B-","AB+","AB-"};
            txtpatientblood.ItemsSource = comboItemBlood;

            string[] comboItemMaritalState = new[] { "Married", "Not Married" };
            txtpatientmaritalstate.ItemsSource = comboItemMaritalState;

            //patients = new ObservableCollection<Patient>(PatientData.GetPatientFromDB());


            //lstvpatient.ItemsSource = patients;
        }

        private void btnSavePatient_Click(object sender, RoutedEventArgs e)
        {
             if (string.IsNullOrEmpty(txtpatientid.Text) || string.IsNullOrEmpty(txtpatientfirstname.Text) || string.IsNullOrEmpty(txtpatientregidate.Text)
                ||string.IsNullOrEmpty(txtpatientlastname.Text)|| string.IsNullOrEmpty(txtpatientage.Text) || string.IsNullOrEmpty(txtpatientgen.Text)
                || string.IsNullOrEmpty(txtpatientoccupation.Text) || string.IsNullOrEmpty(txtpatientbirth.Text) || string.IsNullOrEmpty(txtpatientblood.Text)
                || string.IsNullOrEmpty (txtpatientmaritalstate.Text) || string.IsNullOrEmpty(txtpatientaddress.Text) || string.IsNullOrEmpty((string)txtpatientcity.Text)
                ||string.IsNullOrEmpty(txtpatientcontrctno.Text) || string.IsNullOrEmpty(txtpatientdepartment.Text) || string.IsNullOrEmpty(txtpatientdoctor.Text) )
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }

            Patient patient = new Patient
            {
                PatientId = int.Parse(txtpatientid.Text),
                PatientRegistrationDate = DateTime.Parse(txtpatientregidate.Text),
                PatientFirstName = txtpatientfirstname.Text,
                PatientLastName = txtpatientlastname.Text,
                PatientGender = txtpatientgen.Text,
                PatientOccupation = txtpatientoccupation.Text,
                PatientBirthDate = DateTime.Parse(txtpatientbirth.Text),
                PatientAge = int.Parse(txtpatientage.Text),
                PatientBloodGroup = txtpatientblood.Text,
                PatientMaritalState = txtpatientmaritalstate.Text,
                PatientAddress = txtpatientaddress.Text,
                PatientCity = txtpatientcity.Text,
                PatientContactNumber = txtpatientcontrctno.Text,
                PatientDepartment = txtpatientdepartment.Text,
                PatientDoctorName = txtpatientdoctor.Text
                

            };
            MessageBox.Show("Succesfully Added.");

            txtpatientid.Text = null; 
            txtpatientregidate.Text = null;
            txtpatientfirstname.Text = null;
            txtpatientlastname.Text = null;
            txtpatientgen.Text = null;
            txtpatientoccupation.Text = null;
            txtpatientbirth.Text = null;
            txtpatientage.Text = null;
            txtpatientblood.Text = null;
            txtpatientmaritalstate.Text = null;
            txtpatientaddress.Text = null;
            txtpatientcity.Text = null;
            txtpatientcontrctno.Text = null;
            txtpatientdepartment.Text = null;
            txtpatientdoctor.Text = null;

            //patients.Add(patient);
            //lstvpatient.ItemsSource = patients;

            PatientData.AddPatientToDB(patient);
        }

        private void txtpatientgen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
