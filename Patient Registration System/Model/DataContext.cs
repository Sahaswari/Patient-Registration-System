using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Registration_System.Model
{
    public class DataContext : DbContext
    {
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Test> tests { get; set; }
        public DbSet<User>   users { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Other> others { get; set; }
        public DbSet<Payment> payments { get; set; }


        //public string path = @"C:\Users\Sahaswari\Desktop\Patient Registration System\Patientdatabase5.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { optionsBuilder.UseSqlite($"Data Source=databaseNew.db"); }


    }
}
