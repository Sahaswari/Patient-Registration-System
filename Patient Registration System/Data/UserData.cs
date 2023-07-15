using Patient_Registration_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Registration_System.Data
{
    public static class UserData
    {
        public static void AddUserToDB(User user)
        {
            using (var db = new DataContext())
            {
                db.Add(user);
                db.SaveChanges();
            }
        }

        public static List<User> GetUserFromDB()
        {
            using (var db = new DataContext())
            {
                return db.users.OrderBy(b => b.UserId).ToList();
            }
        }

        public static void UpdateUserToDB(int userKey, string userName, string userPassword, string userFullName, 
            string userAge, string usercontactNumber, string usertype)
        {
            using (var db = new DataContext())
            {
                User user = db.users.Find(userKey);
                user.UserName = userName;
                user.UserPassword = userPassword;
                user.UserFullName = userFullName;
                user.UserAge = int.Parse(userAge);
                user.UserContactNumber = usercontactNumber;
                user.UserType = usertype;
             
                db.SaveChanges();

            }
        }

        public static void DeleteUserFromDB(int userKey)
        {
            using (var db = new DataContext())
            {
                User user = db.users.Single(item => item.UserId == userKey);
                db.users.Remove(user);
                db.SaveChanges();

            }
        }
    }
}
