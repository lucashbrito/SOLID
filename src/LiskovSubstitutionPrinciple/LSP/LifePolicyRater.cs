using System;

namespace LiskovSubstitutionPrinciple.LSP
{
    public class LifePolicyRater: Rater
    {
        private readonly RatingEngine _engine;

        public LifePolicyRater(RatingEngine engine):base (engine)
        {
            _engine = engine;
        }

        public override void Rate(Policy policy)
        {
            ConsoleLogger.Log("Rating LIFE policy...");
            ConsoleLogger.Log("Validating policy.");

            if (policy.DateOfBirth == DateTime.MinValue)
            {
                ConsoleLogger.Log("Life policy must include Date of Birth.");
                return;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                ConsoleLogger.Log("Centenarians are not eligible for coverage.");
                return;
            }
            if (policy.Amount == 0)
            {
                ConsoleLogger.Log("Life policy must include an Amount.");
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
                _engine.Rating = baseRate * 2;
            }
            _engine.Rating = baseRate;

            ConsoleLogger.Log("Life policy finished! ");
        }
    }
}

