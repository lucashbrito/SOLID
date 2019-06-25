using System;
using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple.ISP
{
    public class LifePolicyRater: Rater
    {
        private readonly IRatingUpdater _ratingUpdater;

        public LifePolicyRater(IRatingContext ratingUpdater):base (ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
        }

        public override void Rate(Policy policy)
        {
            _logger.Log("Rating LIFE policy...");
            _logger.Log("Validating policy.");

            if (policy.DateOfBirth == DateTime.MinValue)
            {
                _logger.Log("Life policy must include Date of Birth.");
                return;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                _logger.Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (policy.Amount == 0)
            {
                _logger.Log("Life policy must include an Amount.");
                return;
            }
            var age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }

            var baseRate = policy.Amount * age / 200;

            if (policy.IsSmoker)
            {
                _ratingUpdater.UpdateRating(baseRate * 2);
            }
            _ratingUpdater.UpdateRating(baseRate);

            _logger.Log("Life policy finished! ");
        }
    }
}

