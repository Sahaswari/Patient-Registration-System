using Patient_Registration_System.Data;
using Patient_Registration_System.Model;
using Patient_Registration_System.ViewModel;
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
    /// Interaction logic for NPayementsWindow.xaml
    /// </summary>
    public partial class NPayementsWindow : UserControl
    {
        public ObservableCollection<Patient> patients;
        public NPayementsWindow()
        {
            InitializeComponent();

            patients = new ObservableCollection<Patient>(PatientData.GetPatientFromDB());


            lstvpatientpayment.ItemsSource = patients;

        }

        private void cmbdoctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        
    }
}
