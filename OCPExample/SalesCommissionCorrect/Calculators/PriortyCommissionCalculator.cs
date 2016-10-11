using SalesCommissionCorrect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesCommissionCorrect.Entities;

namespace SalesCommissionCorrect.Calculators
{
    public class PriortyCommissionCalculator : ICommissionCalculator
    {
        public Commission_DTO Calculate(Registration reg, List<Registration> allRegs)
        {
            Commission_DTO retVal = null;
            //  has this course reached priority status?
            var PriorityDate = reg.Course.StartDate.AddDays(-10);

            if (reg.CreationDate > PriorityDate )
            {
                var RegistrationsBeforePriorityDate = allRegs.Where(r => r.Course == reg.Course && reg.CreationDate <= PriorityDate).Count();
                int Threshold =(int)(reg.Course.Capacity * .25m);

                if (RegistrationsBeforePriorityDate > Threshold)
                {
                    retVal =  new Commission_DTO()
                    {
                        CommissionAmount = reg.Course.BasePrice * .03m,
                        CommissionType = "Priorty Commission (3%)",
                        Message = string.Empty
                    };
                }
            }
            return retVal;
        }
    }
}
