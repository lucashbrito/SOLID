using System;

namespace OpenClosedPrinciple.OCP
{
    public class LandPolicyRater : Rater
    {

        private readonly RatingEngine _engine;

        public LandPolicyRater(RatingEngine engine) : base(engine)
        {
            _engine = engine;
        }

        public override void Rate(Policy policy)
        {
            ConsoleLogger.Log("Rating LAND policy...");
            ConsoleLogger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Console.WriteLine("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Console.WriteLine("Insufficient bond amount.");
                return;
            }
            _engine.Rating = policy.BondAmount * 0.05m;
        }
    }
}