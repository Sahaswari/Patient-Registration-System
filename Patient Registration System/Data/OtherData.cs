using Patient_Registration_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Registration_System.Data
{
    public static class OtherData
    {
        public static void AddOtherToDB(Other other)
        {
            using (var db = new DataContext())
            {
                db.Add(other);
                db.SaveChanges();
            }
        }

        public static List<Other> GetOtherFromDB()
        {
            using (var db = new DataContext())
            {
                return db.others.OrderBy(b => b.OtherId).ToList();
            }
        }

        public static void UpdateOtherToDB(int otherKey, string otherName, string otherchargingrate)
        {
            using (var db = new DataContext())
            {
                Other other = db.others.Find(otherKey);
                other.OtherName = otherName;
                other.OtherChargingRate = double.Parse(otherchargingrate);
                db.SaveChanges();

            }
        }

        public static void DeleteOtherFromDB(int otherKey) 
        {
            using(var db = new DataContext()) 
            {
                Other other = db.others.Single(item=> item.OtherId == otherKey);
                db.others.Remove(other);
                db.SaveChanges();

            }
        }
    }
}
