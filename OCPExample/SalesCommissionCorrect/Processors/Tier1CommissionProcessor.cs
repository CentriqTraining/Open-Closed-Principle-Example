using SalesCommissionCorrect.baseClasses;
using SalesCommissionCorrect.Calculators;
using SalesCommissionCorrect.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionCorrect.Processors
{
    public class Tier1CommissionProcessor : CommissionProcessor
    {
        protected override void ProcessCommissionItems(Registration courseRegistration, List<Registration> allCourseRegistrations, List<Commission> commissionItems)
        {
            var Calculator = new ReductionCommissionCalculator(.005m);
            ApplyCommission(Calculator, courseRegistration, allCourseRegistrations, commissionItems);
        }
    }
}
