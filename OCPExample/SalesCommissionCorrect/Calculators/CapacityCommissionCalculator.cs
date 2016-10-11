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
    public class CapacityCommissionCalculator : ICommissionCalculator
    {
        public Commission_DTO Calculate(Registration reg, List<Registration> allRegs)
        {
            Commission_DTO returnVal = null;
            if (allRegs.Count >= reg.Course.Capacity)
            {
                //  Find the registration that caused this course to be at cap
                var lastReg = allRegs
                    .OrderByDescending(r => r.CreationDate).Last();

                if (lastReg == reg)
                {
                    returnVal = new Commission_DTO()
                    {
                        CommissionAmount = reg.Course.BasePrice * Properties.Settings.Default.BaseCommission,
                        CommissionType = "At Capacity",
                        Message = string.Empty
                    };
                }                    
            }
            return returnVal;
        }
    }
}
