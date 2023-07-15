using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Registration_System.Model
{
    public class Patient
    {
        public int PatientId { get; set; }
        public DateTime PatientRegistrationDate { get; set; }       
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientGender { get; set; }
        public string PatientOccupation { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public int PatientAge { get; set; }
        public string PatientBloodGroup { get; set; }
        public string PatientMaritalState { get;set; }
        public string PatientAddress { get;set; }
        public string PatientCity { get;set; }
        public string? PatientContactNumber { get; set; }
        public string PatientDepartment { get; set; }
        public string PatientDoctorName { get; set;}        
        public double PatientPayment { get; set; }
        
        
    }
}
