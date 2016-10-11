using SalesCommissionCorrect.Entities;
using SalesCommissionCorrect.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionCorrect.baseClasses
{
    public abstract class CommissionProcessor
    {
        public void Execute(Registration courseRegistration, List<Registration> allCourseRegistrations, List<Commission> commissionItems)
        {
            ProcessCommissionItems(courseRegistration, allCourseRegistrations, commissionItems);
            ProcessBonusCommissionItems(courseRegistration, allCourseRegistrations, commissionItems);
        }
        protected abstract void ProcessCommissionItems(Registration courseRegistration, List<Registration> allCourseRegistrations, List<Commission> commissionItems);
        protected virtual void ProcessBonusCommissionItems(Registration courseRegistration, List<Registration> allCourseRegistrations, List<Commission> commissionItems)
        {
            foreach (var item in BonusCommissionFactory.GetBonusCalculators())
            {
                ApplyCommission(item, courseRegistration, allCourseRegistrations, commissionItems);
            }
        }
        protected void ApplyCommission(ICommissionCalculator Calculator, Registration courseRegistration, List<Registration> allCourseRegistrations, List<Commission> commissionItems)
        {
            var item = Calculator.Calculate(courseRegistration, allCourseRegistrations);
            if (item != null)
            {
                var msg = item.Message == string.Empty
                    ? item.CommissionType : item.CommissionType + " - " + item.Message;

                commissionItems.Add(new Commission()
                {
                    Description = msg,
                    Registration = courseRegistration,
                    Total = item.CommissionAmount
                });
            }
        }
    }
}
