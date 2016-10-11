using SalesCommissionCorrect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesCommissionCorrect.baseClasses;
using SalesCommissionCorrect.Entities;

namespace SalesCommissionCorrect.Calculators
{
    public class CappedCommissionCalculator : ICommissionCalculator
    {
        public Commission_DTO Calculate(Registration reg, List<Registration> allRegs)
        {
            Commission_DTO retVal = null;
            // Find percent Discount 
            decimal discount = reg.Discount * 100;

            if (discount <= 10)
            {
                retVal = new Commission_DTO()
                {
                    CommissionAmount = reg.Course.BasePrice *  Properties.Settings.Default.BaseCommission,
                    CommissionType = "Discount < 10%",
                    Message = string.Empty
                };
            }
            else
            {
                retVal = new Commission_DTO()
                {
                    CommissionAmount = 0,
                    CommissionType = "Discount > 10%",
                    Message = string.Empty
                };

            }
            return retVal;
        }
    }
}
