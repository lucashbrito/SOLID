namespace LiskovSubstitutionPrinciple.LSP
{
    public class FloodPolicyRater : Rater
    {
        private readonly RatingEngine _engine;

        public FloodPolicyRater(RatingEngine engine) : base(engine)
        {
        }

        public override void Rate(Policy policy)
        {
            ConsoleLogger.Log("Rating AUTO policy...");
            ConsoleLogger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                ConsoleLogger.Log("Flood policy must specify bond amoutn and valuation");
                return;
            }

            if (policy.ElevationAboveSeaLevelFeet <= 0)
            {
                ConsoleLogger.Log("Food policy is not available for elevations at or below sea level");
                return;
            }

        }
    }
}
