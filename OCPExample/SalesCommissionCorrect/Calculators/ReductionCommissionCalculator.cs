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
    public class ReductionCommissionCalculator : ICommissionCalculator
    {
        private decimal _ReductionRate;
        public ReductionCommissionCalculator(decimal reductionRate)
        {
            _ReductionRate = reductionRate;
        }
        public Commission_DTO Calculate(Registration reg, List<Registration> allRegs)
        {
            Commission_DTO retVal = null;
            // Find percent Discount 
            decimal discount = reg.Discount * 100;

            //  multiply discount by reductionRate
            decimal CommissionReduction = discount * _ReductionRate;

            // subtract CommissionReduction from the commission rate 
            var FinalRate = Properties.Settings.Default.BaseCommission - CommissionReduction;

            decimal reductionrate = _ReductionRate * 100;
            decimal commreductionpercent = FinalRate * 100;

            if (FinalRate > 0)
            {
                retVal = new Commission_DTO()
                {
                    CommissionAmount = reg.Course.BasePrice * FinalRate,
                    CommissionType = "Reduced",
                    Message = $"({reductionrate:n2} @ {discount:n2}%) = {commreductionpercent:n2}%"
                };
            }
            else
            {
                retVal = new Commission_DTO()
                {
                    CommissionAmount = 0,
                    CommissionType = "Reduced Comm",
                    Message = "Discount > max"
                };
            }
            return retVal;
        }
    }
}
