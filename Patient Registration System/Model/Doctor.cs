using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Registration_System.Model
{
    public class Doctor
    {
        public int DoctorId { get; set;}
        public string? DoctorName {get;set; }
        public int DoctorAge { get;set;}
        public string? ContactNumber { get; set; }
        public string? MORegistrationNo { get;set; }
        public string? Specilization { get;set; }
        public double ChargingRate { get;set; }
        //public List<Patient> Patients1 { get; set; }
    }
}
