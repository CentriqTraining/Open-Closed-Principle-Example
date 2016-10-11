using SalesCommissionCorrect.baseClasses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesCommissionCorrect.Entities;
using SalesCommissionCorrect.Calculators;
using System.Collections.ObjectModel;

namespace SalesCommissionCorrect.Processors
{
    public class Tier3CommissionProcessor : CommissionProcessor
    {
        protected override void ProcessBonusCommissionItems(Registration courseRegistration, List<Registration> allCourseRegistrations, List<Commission> commissionItems)
        {
            // no bonus commissions at tier 2
        }

        protected override void ProcessCommissionItems(Registration courseRegistration, List<Registration> allCourseRegistrations, List<Commission> commissionItems)
        {
            var Calculator = new CappedCommissionCalculator();
            ApplyCommission(Calculator, courseRegistration, allCourseRegistrations, commissionItems);
        }
    }
}
