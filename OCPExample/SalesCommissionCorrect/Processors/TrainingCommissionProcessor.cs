using SalesCommissionCorrect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesCommissionCorrect.Entities;
using SalesCommissionCorrect.baseClasses;
using System.Collections.ObjectModel;

namespace SalesCommissionCorrect.Processors
{
    public class TrainingCommissionProcessor : CommissionProcessor
    {
        protected override void ProcessBonusCommissionItems(Registration courseRegistration, List<Registration> allCourseRegistrations, List<Commission> commissionItems)
        {
            //  Training...no commission
        }

        protected override void ProcessCommissionItems(Registration courseRegistration, List<Registration> allCourseRegistrations, List<Commission> commissionItems)
        {
            //  Training...no commission
        }
    }
}
