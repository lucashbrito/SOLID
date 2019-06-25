using System;
using DependencyInversionPrinciple.Core.Interfaces;
using DependencyInversionPrinciple.Core.Model;

namespace DependencyInversionPrinciple.Core.Raters
{
    public class LandPolicyRater : Rater
    {
        public LandPolicyRater(ILoggerConsole logger) : base(logger)
        {

        }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating LAND policy...");
            Logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Console.WriteLine("Land policy must specify Bond Amount and Valuation.");
                return 0m;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Logger.Log("Insufficient bond amount.");
                return 0m;
            }

            Logger.Log("Land policy finished! ");

            return policy.BondAmount * 0.05m;
        }
    }
}