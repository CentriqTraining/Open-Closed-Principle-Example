using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionViolation.Entities
{
    public class Registration
    {
        public int ID { get; set; }
        public Customer Customer { get; set; }
        public Course Course { get; set; }
        public Employee Marketer { get; set;  }
        public DateTime CreationDate { get; set; }
        public decimal Discount { get; set; }

        public decimal SalePrice {
            get
            {
                return Course?.BasePrice * (1 - Discount) ?? 0;
            }
        }
    }
}
