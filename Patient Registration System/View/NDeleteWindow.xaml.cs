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
    /// Interaction logic for NDeleteWindow.xaml
    /// </summary>
    public partial class NDeleteWindow : UserControl
    {
        public ObservableCollection<Patient> patients;
        private Patient patientselectedItem;
        private int patientId;
        public NDeleteWindow()
        {
            InitializeComponent();

            patients = new ObservableCollection<Patient>(PatientData.GetPatientFromDB());


            lstvpatient.ItemsSource = patients;

            patientselectedItem = null;
        }

        private void lstvpatient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patientselectedItem = (Patient)lstvpatient.SelectedItem;
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
