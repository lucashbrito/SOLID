using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple.ISP
{
    public class FloodPolicyRater : Rater
    {
        public FloodPolicyRater(IRatingContext context) : base(context)
        {
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating AUTO policy...");
            _logger.Log("Validating policy.");

            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.Log("Flood policy must specify bond amoutn and valuation");
                return;
            }

            if (policy.ElevationAboveSeaLevelFeet <= 0)
            {
                _logger.Log("Food policy is not available for elevations at or below sea level");
            }
        }
    }
}
