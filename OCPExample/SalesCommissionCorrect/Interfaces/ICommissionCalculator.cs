using SalesCommissionCorrect.baseClasses;
using SalesCommissionCorrect.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionCorrect.Interfaces
{
    public interface ICommissionCalculator
    {
        Commission_DTO Calculate(Registration reg, List<Registration> allRegs);
    }
}
