using SalesCommissionViolation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionViolation.Entities
{
    public class Customer : IPerson
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Course> Registrations { get; set; }
    }
}
