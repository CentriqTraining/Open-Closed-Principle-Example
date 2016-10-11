using SalesCommissionViolation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionViolation.Entities
{
    public enum TierLevel
    {
        Training,
        Normal,
        Level1,
        Level2,
        Level3
    }

    public class Employee :IPerson
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TierLevel CommissionTierLevel { get; set; }
    }
}
