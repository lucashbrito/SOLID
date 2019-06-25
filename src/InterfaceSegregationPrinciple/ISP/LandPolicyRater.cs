using System;
using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple.ISP
{
    public class LandPolicyRater : Rater
    {

        private readonly IRatingContext _ratingUpdater;

        public LandPolicyRater(IRatingContext ratingUpdater) : base(ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating LAND policy...");
            _logger.Log("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Console.WriteLine("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logger.Log("Insufficient bond amount.");
                return;
            }
            _ratingUpdater.UpdateRating(policy.BondAmount * 0.05m);

            _logger.Log("Land policy finished! ");
        }
    }
}