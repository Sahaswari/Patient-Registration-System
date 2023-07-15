using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Registration_System.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserFullName { get; set; }
        public int UserAge { get; set; }        
        public string UserContactNumber { get; set; }
        public string UserType { get; set; }

    }
}
