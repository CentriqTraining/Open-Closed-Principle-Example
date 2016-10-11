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
    public class JustInTimeCommission : ICommissionCalculator
    {
        public Commission_DTO Calculate(Registration reg, List<Registration> allRegs)
        {
            var courseStart = reg.Course.StartDate;
            var regDate = reg.CreationDate;
            if ((courseStart-regDate).TotalDays <= 2)
            {
                return new Commission_DTO()
                {
                    CommissionAmount = reg.Course.BasePrice * .01m,
                    CommissionType = "JIT",
                    Message = $"{(courseStart - regDate).TotalDays} day before class"
                };
            }
            else
            {
                return null;
            }
        }
    }
}
