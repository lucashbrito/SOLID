using DependencyInversionPrinciple.Core.Interfaces;
using DependencyInversionPrinciple.Core.Model;

namespace DependencyInversionPrinciple.Core.Raters
{
    public class FloodPolicyRater : Rater
    {
        public FloodPolicyRater(ILoggerConsole logger) : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");

            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Flood policy must specify bond amoutn and valuation");
                return 0m;
            }

            if (policy.ElevationAboveSeaLevelFeet <= 0)
            {
                Logger.Log("Food policy is not available for elevations at or below sea level");
                return 0m;
            }
            return 0m;
        }
    }
}
