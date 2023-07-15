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
    /// Interaction logic for PatientsWindow.xaml
    /// </summary>
    public partial class PatientsWindow : UserControl
    {
        public ObservableCollection<Patient> patients;
        private Patient patientselectedItem;
        private int patientId;
        public PatientsWindow()
        {
            InitializeComponent();

            string[] comboItemGen = new[] { "Male", "Female" };
            txtpatientgen.ItemsSource = comboItemGen;

            string[] comboItemBlood = new[] { "O+", "O-", "A+", "A-", "B+", "B-", "AB+", "AB-" };
            txtpatientblood.ItemsSource = comboItemBlood;

            string[] comboItemMaritalState = new[] { "Married", "Not Married" };
            txtpatientmaritalstate.ItemsSource = comboItemMaritalState;

            patients = new ObservableCollection<Patient>(PatientData.GetPatientFromDB());


            lstvpatient.ItemsSource = patients;

            patientselectedItem = null;
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

            patients.Add(patient);
            lstvpatient.ItemsSource = patients;

            PatientData.AddPatientToDB(patient);
        }

        private void lstvpatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patientselectedItem = (Patient)lstvpatient.SelectedItem;
        }

        private void patientedit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Follow the Below Steps.\n  1) Please Update the Data.\n  2) Then Select Data Again. \n  3) Then Press Update Button.");
            Button? b = sender as Button;

            Patient? patient = b?.CommandParameter as Patient;

            txtpatientid.Text = patient?.PatientId.ToString();
            txtpatientregidate.Text = patient.PatientRegistrationDate.ToString();
            txtpatientfirstname.Text = patient.PatientFirstName;
            txtpatientlastname.Text = patient.PatientLastName;
            txtpatientgen.Text = patient.PatientGender;
            txtpatientoccupation.Text = patient.PatientOccupation;
            txtpatientbirth.Text = patient.PatientBirthDate.ToString();
            txtpatientage.Text = patient.PatientAge.ToString();
            txtpatientblood.Text = patient.PatientBloodGroup;
            txtpatientmaritalstate.Text = patient.PatientMaritalState;
            txtpatientaddress.Text = patient.PatientAddress;
            txtpatientcity.Text = patient.PatientCity;
            txtpatientcontrctno.Text = patient.PatientContactNumber;
            txtpatientdepartment.Text = patient.PatientDepartment;
            txtpatientdoctor.Text = patient.PatientDoctorName;

            patientId = patient.PatientId;

        }

       


        private void btnpatientupdate_Click(object sender, RoutedEventArgs e)
        {
            if (patientselectedItem != null)

            {
                PatientData.UpdatePatientToDB(patientId, txtpatientregidate.Text, txtpatientfirstname.Text, txtpatientlastname.Text, txtpatientgen.Text,
                txtpatientoccupation.Text, txtpatientbirth.Text, txtpatientage.Text, txtpatientblood.Text, txtpatientmaritalstate.Text, txtpatientaddress.Text,
                txtpatientcity.Text, txtpatientcontrctno.Text, txtpatientdepartment.Text, txtpatientdoctor.Text);

                MessageBox.Show("DataBase Is Succesfully Updated. Later Data Will Show.");

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

                lstvpatient.ItemsSource = patients;
            }

            else
            {
                MessageBox.Show("Please Select Data.");
            }

        }

        private void btnDeletePatient_Click(object sender, RoutedEventArgs e)
        {
            if (patientselectedItem != null)
            {
                PatientData.DeletePatientFromDB(patientselectedItem.PatientId);
                System.Windows.MessageBox.Show("Your Selected Data is Deleted Successfully. Later Data Will Show.");
            }
            else
            {
                MessageBox.Show("Please Select Data.");
            }
        }

 
    }
}
