using SalesCommissionCorrect.Calculators;
using SalesCommissionCorrect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionCorrect.baseClasses
{
    public static class BonusCommissionFactory
    {
        public static List<ICommissionCalculator> GetBonusCalculators()
        {
            return new List<ICommissionCalculator>()
            {
                new CapacityCommissionCalculator(),
                new JustInTimeCommission(),
                new PriortyCommissionCalculator()
            };
        }
    }
}
