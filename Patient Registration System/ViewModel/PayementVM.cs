using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Patient_Registration_System.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Patient_Registration_System.ViewModel
{
    public partial class PayementVM : ObservableObject
    {

        [ObservableProperty]
        ObservableCollection<string> ldoctors;

        [ObservableProperty]
        ObservableCollection<string> ltests;

        [ObservableProperty]
        ObservableCollection<string> lothers;

        [ObservableProperty]
        ObservableCollection<int> lpatients;

        [ObservableProperty]
        double fixedcharge = 1000;

        [ObservableProperty]
        double correctvalue;




        PayementVM()
        {
            using (var db = new DataContext())
            {
                var list1 = db.doctors.Select(u => u.DoctorName).ToList();
                ldoctors = new ObservableCollection<string>(list1);
            }

            using (var db = new DataContext())
            {
                var list2 = db.tests.Select(u => u.TestName).ToList();
                ltests = new ObservableCollection<string>(list2);
            }

            using (var db = new DataContext())
            {
                var list3 = db.others.Select(u => u.OtherName).ToList();
                lothers = new ObservableCollection<string>(list3);
            }

            using (var db = new DataContext())
            {
                var list4 = db.patients.Select(u => u.PatientId).ToList();
                lpatients = new ObservableCollection<int>(list4);
            }
        }




        private double selectedDoctorValue;
        public double SelectedDoctorValue
        {
            get { return selectedDoctorValue; }
            set { SetProperty(ref selectedDoctorValue, value); }
        }

        private string selectedDoctor;
        public string SelectedDoctor
        {
            get { return selectedDoctor; }
            set
            {
                SetProperty(ref selectedDoctor, value);


                using (var db = new DataContext())
                {
                    var doctor = db.doctors.FirstOrDefault(u => u.DoctorName == selectedDoctor);
                    if (doctor != null)
                    {
                        SelectedDoctorValue = doctor.ChargingRate;
                    }
                }
            }
        }




        private double selectedTestValue;
        public double SelectedTestValue
        {
            get { return selectedTestValue; }
            set { SetProperty(ref selectedTestValue, value); }
        }

        private string selectedTest;
        public string SelectedTest
        {
            get { return selectedTest; }
            set
            {
                SetProperty(ref selectedTest, value);


                using (var db = new DataContext())
                {
                    var test = db.tests.FirstOrDefault(u => u.TestName == selectedTest);
                    if (test != null)
                    {
                        SelectedTestValue = test.TestChargingRate;
                    }
                }
            }
        }




        private double selectedOtherValue;
        public double SelectedOtherValue
        {
            get { return selectedOtherValue; }
            set { SetProperty(ref selectedOtherValue, value); }
        }

        private string selectedOther;
        public string SelectedOther
        {
            get { return selectedOther; }
            set
            {
                SetProperty(ref selectedOther, value);


                using (var db = new DataContext())
                {
                    var other = db.others.FirstOrDefault(u => u.OtherName == selectedOther);
                    if (other != null)
                    {
                        SelectedOtherValue = other.OtherChargingRate;
                    }
                }
            }
        }



        private string selectedPatientFirstName;
        public string SelectedPatientFirstName
        {
            get { return selectedPatientFirstName; }
            set { SetProperty(ref selectedPatientFirstName, value); }
        }

        private string selectedPatientLastName;
        public string SelectedPatientLastName
        {
            get { return selectedPatientLastName; }
            set { SetProperty(ref selectedPatientLastName, value); }
        }

        private DateTime selectedPatientRegDate;
        public DateTime SelectedPatientRegDate
        {
            get { return selectedPatientRegDate; }
            set { SetProperty(ref selectedPatientRegDate, value); }
        }

        private string selectedPatientContactNo;
        public string SelectedPatientContactNo
        {
            get { return selectedPatientContactNo; }
            set { SetProperty(ref selectedPatientContactNo, value); }
        }

        private int selectedPatient;
        public int SelectedPatient
        {
            get { return selectedPatient; }
            set
            {
                SetProperty(ref selectedPatient, value);


                using (var db = new DataContext())
                {
                    var patient = db.patients.FirstOrDefault(u => u.PatientId == selectedPatient);
                    if (patient != null)
                    {
                        SelectedPatientFirstName = patient.PatientFirstName;
                        SelectedPatientLastName = patient.PatientLastName;
                        SelectedPatientRegDate = patient.PatientRegistrationDate;
                        SelectedPatientContactNo = patient.PatientContactNumber;
                    }
                }
            }
        }






        private double _value;

        public double Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }


        }


        [RelayCommand]
        void AddValues()
        {
            using (var db = new DataContext())
            {
                var patient = db.patients.FirstOrDefault(u => u.PatientId == selectedPatient);
                if (patient != null)
                {
                    _value = patient.PatientPayment + fixedcharge + selectedOtherValue + selectedDoctorValue + selectedTestValue;
                    fixedcharge = 0;
                    selectedOtherValue = 0;
                    selectedDoctorValue = 0;
                    selectedTestValue = 0;

                    patient.PatientPayment = _value;
                    db.SaveChanges();

                    OnPropertyChanged(nameof(Value));
                    MessageBox.Show("Calculated Successfully \n The total bill is Rs. " + _value.ToString());
                }
            }
        }



        [RelayCommand]
        void RemoveValues()
        {
            using (var db = new DataContext())
            {
                var patient = db.patients.FirstOrDefault(u => u.PatientId == selectedPatient);
                if (patient != null)
                {
                    _value = patient.PatientPayment - correctvalue;
                    OnPropertyChanged(nameof(Value));

                    patient.PatientPayment = _value;
                    db.SaveChanges();

                    MessageBox.Show("Value deducted Successfully \n The total bill is Rs. " + _value.ToString());
                }
            }
        }








    }

}
       
