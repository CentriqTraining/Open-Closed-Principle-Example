using SalesCommissionViolation.Entities;
using SalesCommissionViolation.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SalesCommissionViolation.TestData
{
    public static class TestUtilities
    {
        public static List<T> GenerateTestNames<T>(int count) where T : IPerson, new()
        {
            //  Load firstnames
            var file1 = File.Open(@"TestData\xmlFirstNames.xml", FileMode.Open);
            XElement XmlFirst = XElement.Load(file1);
            var FirstNames = (from name in XmlFirst.Descendants("name")
                              select name.Value).ToList();
            file1.Close();

            //  Load lastnames
            var file2 = File.Open(@"TestData\xmlLastNames.xml", FileMode.Open);
            XElement XmlLast = XElement.Load(file2);
            var LastNames = (from name in XmlLast.Descendants("name")
                             select name.Value).ToList();
            file2.Close();

            //  put random firstname with random lastname  [count] number of times
            var rand = new Random();
            var names = new List<T>();
            for (int i = 0; i < count; i++)
            {
                T newItem = new T();
                newItem.ID = i;
                newItem.FirstName = FirstNames[rand.Next(0, FirstNames.Count - 1)];
                newItem.LastName = LastNames[rand.Next(0, LastNames.Count - 1)];
                names.Add(newItem);
            }

            return names;
        }
        public static void AssignTierLevel(List<Employee> list, int trainingCount, int NormalCount, int level1Count, int level2Count, int level3Count)
        {
            for (int i = 0; i < list.Count; i++)
            {
                TierLevel lvl = TierLevel.Level3;
                if (trainingCount > 0)
                {
                    lvl = TierLevel.Training;
                    trainingCount--;
                }
                else if (NormalCount > 0)
                {
                    NormalCount--;
                    lvl = TierLevel.Normal;
                }
                else if (level1Count > 0)
                {
                    level1Count--;
                    lvl = TierLevel.Level1;
                }
                else if (level2Count > 0)
                {
                    level2Count--;
                    lvl = TierLevel.Level2;
                }
                list[i].CommissionTierLevel = lvl;
            }
        }
        public static List<Course> CreateCourses(int count)
        {
            var retVal = new List<Course>();
            string[] prefixes = { "CIS", "FUN", "LOG", "DES" };
            var rand = new Random(DateTime.Now.DayOfYear + DateTime.Now.Millisecond);
            for (int i = 0; i < count; i++)
            {
                bool IsNewValue = false;

                string NewValue = string.Empty;
                while (!IsNewValue)
                {
                    // Get random prefix
                    var RandomSubscript = rand.Next(0, prefixes.Length - 1);
                    var Prefix = prefixes[RandomSubscript];

                    // append random 3 digit number
                    var RandomNumber = rand.Next(1, 350).ToString().PadLeft(3, '0');
                    NewValue = Prefix + RandomNumber;

                    var dupecount = retVal.Where(v => v.Description == NewValue).Count();
                    if (dupecount == 0)
                        IsNewValue = true;
                }

                // get random date in previous month
                var startDate = DateTime.Now.AddMonths(-1).AddDays(-DateTime.Now.Day + 1).AddMinutes(rand.Next(1, 144));

                var NewCourse = new Course()
                {
                    BasePrice = 1000,
                    Description = NewValue,
                    StartDate = DateTime.Now.AddMonths(-1),
                    EndDate = DateTime.Now.AddMonths(-1).AddDays(3),
                    Capacity = 40,
                    ID= i
                };
                retVal.Add(NewCourse);
            }
            return retVal;
        }

        public static List<Registration> CreateRegistrations(List<Employee> marketerList, List<Customer> customerList, List<Course> courseList, int regCount)
        {
            List<Registration> retVal = new List<Registration>();

            var rand = new Random(DateTime.Now.DayOfYear + DateTime.Now.Millisecond);

            for (int i = 0; i < regCount; i++)
            {
                // get random customer
                //  register them for random course
                // giving credi to random marketer
                var cust = rand.Next(0, customerList.Count);
                var course = rand.Next(0, courseList.Count);
                var mark = rand.Next(0, marketerList.Count);

                var newDate = courseList[course].StartDate.AddDays(-rand.Next(1,45));

                var newreg = new Registration()
                {
                    Course = courseList[course],
                    CreationDate = newDate,
                    Customer = customerList[cust],
                    Discount = (decimal)rand.Next(1, 12)/100,
                    Marketer = marketerList[mark],
                    ID=i
                };
                retVal.Add(newreg);
            }
            return retVal;
        }
    }
}
