using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionViolation.Entities
{
    public class Commission
    {
        public int ID { get; set; }
        public Registration Registration { get; set; }
        public string Description { get; set;  }
        public decimal Total { get; set;  }
    }
}
