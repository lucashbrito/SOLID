using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple.ISP
{
    public class AutoPolicyRater: Rater
    {
        private readonly IRatingUpdater _ratingUpdater;

        public AutoPolicyRater(IRatingUpdater ratingUpdater):base(ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating AUTO policy...");
            _logger.Log("Validating policy.");
            if (string.IsNullOrEmpty(policy.Make))
            {
                _logger.Log("Auto policy must specify Make");
                return;
            }

            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _ratingUpdater.UpdateRating(1000m);
                }

                _ratingUpdater.UpdateRating(900m);
            }
        }
    }
}
