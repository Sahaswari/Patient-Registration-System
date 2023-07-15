using Microsoft.VisualBasic;
using Patient_Registration_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Registration_System.Data
{
    public static class PatientData
    {
        public static void AddPatientToDB(Patient patient)
        {
            using (var db = new DataContext())
            {
                db.Add(patient);
                db.SaveChanges();
            }
        }

        public static List<Patient> GetPatientFromDB()
        {
            using (var db = new DataContext())
            {
                return db.patients.OrderBy(b => b.PatientId).ToList();
            }
        }

        public static void UpdatePatientToDB(int patientKey, string patientRegistrationdate, string patientFirstName, string patientLastName, string patientGender,
            string patientOccupation, string patientDateofBirth, string patientAge, string patientBlood, string patientMaritalState, string patientAddress,
            string patientCity, string patientContactNo, string patientDepartment, string patientDoctor)
        {
            using (var db = new DataContext())
            {
                Patient patient = db.patients.Find(patientKey);
                patient.PatientRegistrationDate = DateTime.Parse(patientRegistrationdate);
                patient.PatientFirstName = patientFirstName;
                patient.PatientLastName = patientLastName;
                patient.PatientGender = patientGender;
                patient.PatientOccupation = patientOccupation;
                patient.PatientBirthDate = DateTime.Parse(patientDateofBirth);
                patient.PatientAge = int.Parse(patientAge);
                patient.PatientBloodGroup = patientBlood;
                patient.PatientMaritalState = patientMaritalState;
                patient.PatientAddress = patientAddress;
                patient.PatientCity = patientCity;
                patient.PatientContactNumber = patientContactNo;
                patient.PatientDepartment = patientDepartment;
                patient.PatientDoctorName = patientDoctor;
                db.SaveChanges();

            }
        }

        public static void DeletePatientFromDB(int patientKey)
        {
            using (var db = new DataContext())
            {
                Patient patient = db.patients.Single(item => item.PatientId == patientKey);
                db.patients.Remove(patient);
                db.SaveChanges();

            }
        }
    }
}
