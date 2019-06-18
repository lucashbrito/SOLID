namespace OpenClosedPrinciple.OCP
{
    public class AutoPolicyRater: Rater
    {
        private readonly RatingEngine _engine;

        public AutoPolicyRater(RatingEngine engine):base(engine)
        {
            _engine = engine;
        }

        public override void Rate(Policy policy)
        {
            ConsoleLogger.Log("Rating AUTO policy...");
            ConsoleLogger.Log("Validating policy.");
            if (string.IsNullOrEmpty(policy.Make))
            {
                ConsoleLogger.Log("Auto policy must specify Make");
                return;
            }

            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _engine.Rating = 1000m;
                }

                _engine.Rating = 900m;
            }

        }
    }
}
