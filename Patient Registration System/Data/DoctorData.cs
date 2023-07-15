using Patient_Registration_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Registration_System.Data
{
    public static class DoctorData
    {
        public static void AddDoctorToDB(Doctor doctor)
        {
            using(var db = new DataContext()) 
            {
                db.Add(doctor);
                db.SaveChanges();
            }
        }

       public static List<Doctor> GetDoctorFromDB()
        {
            using( var db = new DataContext())
            {
                return db.doctors.OrderBy(b=>b.DoctorId).ToList();
            }
        }

        public static void UpdateDoctorToDB(int doctorKey,string doctorName, string doctorAge, string contactNumber, string moRegistrationNo, string specilization
            ,string chargingrate)
        {
            using(var db = new DataContext())
            {
                Doctor doctor = db.doctors.Find(doctorKey);
               
                doctor.DoctorName = doctorName;
                doctor.DoctorAge = int.Parse(doctorAge);
                doctor.ContactNumber = contactNumber;
                doctor.MORegistrationNo = moRegistrationNo;
                doctor.Specilization = specilization;
                doctor.ChargingRate = double.Parse(chargingrate);
                db.SaveChanges();

            }
        }

        public static void DeleteDoctorFromDB(int doctorKey)
        {
            using (var db = new DataContext())
            {
                Doctor doctor = db.doctors.Single(item => item.DoctorId == doctorKey);
                db.doctors.Remove(doctor);
                db.SaveChanges();

            }
        }
    }
}
