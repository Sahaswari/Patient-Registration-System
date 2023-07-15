using Patient_Registration_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Registration_System.Data
{
    public static class TestData
    {
        public static void AddTestToDB(Test test)
        {
            using (var db = new DataContext())
            {
                db.Add(test);
                db.SaveChanges();
            }
        }

        public static List<Test> GetTestFromDB()
        {
            using (var db = new DataContext())
            {
                return db.tests.OrderBy(b => b.TestId).ToList();
            }
        }

        public static void UpdateTestToDB(int testKey, string testName, string testchargingrate)
        {
            using (var db = new DataContext())
            {
                Test test = db.tests.Find(testKey);
                test.TestName = testName;
                test.TestChargingRate = double.Parse(testchargingrate);
                db.SaveChanges();

            }
        }

        public static void DeleteTestFromDB(int testKey)
        {
            using (var db = new DataContext())
            {
                Test test = db.tests.Single(item => item.TestId == testKey);
                db.tests.Remove(test);
                db.SaveChanges();

            }
        }
    }
}
