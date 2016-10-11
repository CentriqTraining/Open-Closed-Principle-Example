using SalesCommissionViolation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCommissionViolation.Processors
{
    public class TheWrongWay
    {
        public void CalculateCommission(List<Registration> regs, List<Commission> commissions)
        {
            foreach (var item in regs)
            {
                decimal reductionrate;
                decimal discount;
                decimal Commreductionpercent;
                DateTime CourseStart;
                DateTime RegDate;
                switch (item.Marketer.CommissionTierLevel)
                {
                    case TierLevel.Training:
                        break;
                    case TierLevel.Normal:
                        // look at discount and adjust accordingly
                        discount = item.Discount;
                        reductionrate = 1.0m;
                        Commreductionpercent = discount - (item.Discount * reductionrate);
                        if (Commreductionpercent > 0)
                        {
                            commissions.Add(new Commission()
                            {
                                Description = $"Reduced - ({reductionrate:n2} @ {discount:n2}%) = {Commreductionpercent:n2}%",
                                Registration = item,
                                Total = item.Course.BasePrice * Commreductionpercent
                            });
                        }

                        // at capacity bonus commission 
                        if (regs.Count >= item.Course.Capacity)
                        {
                            //  Find the registration that caused this course to be at cap
                            var lastReg = regs
                                .OrderByDescending(r => r.CreationDate).Last();

                            if (lastReg == item)
                            {
                                commissions.Add(new Commission()
                                {
                                    Description = "At Capacity",
                                    Registration = item,
                                    Total = item.Course.BasePrice * Properties.Settings.Default.BaseCommission
                                });
                            }
                        }

                        //  Just in time Commission
                        CourseStart = item.Course.StartDate;
                        RegDate = item.CreationDate;
                        if ((CourseStart - RegDate).TotalDays <= 2)
                        {
                            commissions.Add(new Commission()
                            {
                                Description = $"JIT - {(CourseStart - RegDate).TotalDays} days before class",
                                Total = item.Course.BasePrice * .01m,
                                Registration = item
                            });
                        }
                        break;
                    case TierLevel.Level1:
                        // look at discount and adjust accordingly
                        discount = item.Discount;
                        reductionrate = .5m;
                        Commreductionpercent = discount - (item.Discount * reductionrate);
                        if (Commreductionpercent > 0)
                        {
                            commissions.Add(new Commission()
                            {
                                Description = $"Reduced - ({reductionrate:n2} @ {discount:n2}%) = {Commreductionpercent:n2}%",
                                Registration = item,
                                Total = item.Course.BasePrice * Commreductionpercent
                            });
                        }

                        // at capacity bonus commission 
                        if (regs.Count >= item.Course.Capacity)
                        {
                            //  Find the registration that caused this course to be at cap
                            var lastReg = regs
                                .OrderByDescending(r => r.CreationDate).Last();

                            if (lastReg == item)
                            {
                                commissions.Add(new Commission()
                                {
                                    Description = "At Capacity",
                                    Registration = item,
                                    Total = item.Course.BasePrice * Properties.Settings.Default.BaseCommission
                                });
                            }
                        }

                        //  Just in time Commission
                        CourseStart = item.Course.StartDate;
                        RegDate = item.CreationDate;
                        if ((CourseStart - RegDate).TotalDays <= 2)
                        {
                            commissions.Add(new Commission()
                            {
                                Description = $"JIT - {(CourseStart - RegDate).TotalDays} days before class",
                                Total = item.Course.BasePrice * .01m,
                                Registration = item
                            });
                        }
                        break;
                    case TierLevel.Level2:
                        // look at discount and adjust accordingly
                        discount = item.Discount;
                        reductionrate = .25m;
                        Commreductionpercent = discount - (item.Discount * reductionrate);
                        if (Commreductionpercent > 0)
                        {
                            commissions.Add(new Commission()
                            {
                                Description = $"Reduced - ({reductionrate:n2} @ {discount:n2}%) = {Commreductionpercent:n2}%",
                                Registration = item,
                                Total = item.Course.BasePrice * Commreductionpercent
                            });
                        }

                        // at capacity bonus commission 
                        if (regs.Count >= item.Course.Capacity)
                        {
                            //  Find the registration that caused this course to be at cap
                            var lastReg = regs
                                .OrderByDescending(r => r.CreationDate).Last();

                            if (lastReg == item)
                            {
                                commissions.Add(new Commission()
                                {
                                    Description = "At Capacity",
                                    Registration = item,
                                    Total = item.Course.BasePrice * Properties.Settings.Default.BaseCommission
                                });
                            }
                        }

                        //  Just in time Commission
                        CourseStart = item.Course.StartDate;
                        RegDate = item.CreationDate;
                        if ((CourseStart - RegDate).TotalDays <= 2)
                        {
                            commissions.Add(new Commission()
                            {
                                Description = $"JIT - {(CourseStart - RegDate).TotalDays} days before class",
                                Total = item.Course.BasePrice * .01m,
                                Registration = item
                            });
                        }
                        break;
                    case TierLevel.Level3:
                        // look at discount and keep the same unless higher than 10%...then nothing
                        discount = item.Discount;
                        if (discount > .10m)
                        {
                            commissions.Add(new Commission()
                            {
                                Description = $"Discount < 10%",
                                Registration = item,
                                Total = item.Course.BasePrice * Properties.Settings.Default.BaseCommission
                            });
                        }
                        else
                        {
                            commissions.Add(new Commission()
                            {
                                Description = $"Discount > 10%",
                                Registration = item,
                                Total = 0
                            });
                        }
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
