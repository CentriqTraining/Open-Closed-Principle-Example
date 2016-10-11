using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesCommissionCorrect.Entities;
using SalesCommissionCorrect.baseClasses;
using SalesCommissionCorrect.Calculators;
using System.Collections.ObjectModel;

namespace SalesCommissionCorrect.Processors
{
    public class DefaultCommissionProcessor : CommissionProcessor
    {
        protected override void ProcessCommissionItems(Registration courseRegistration, List<Registration> allCourseRegistrations, List<Commission> commissionItems)
        {
            var Calculator = new ReductionCommissionCalculator(.01m);
            ApplyCommission(Calculator, courseRegistration, allCourseRegistrations, commissionItems);
        }
    }
}
