using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionViolation.Entities
{
    public class Commission_DTO
    {
        public string CommissionType { get; set; }
        public string Message { get; set; }
        public decimal CommissionAmount { get; set;  }
    }
}
