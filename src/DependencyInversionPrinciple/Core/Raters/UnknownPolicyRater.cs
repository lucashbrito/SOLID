using DependencyInversionPrinciple.Core.Interfaces;
using DependencyInversionPrinciple.Core.Model;

namespace DependencyInversionPrinciple.Core.Raters
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(ILoggerConsole logger) : base(logger)
        {
        }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Unknown policy type");
            return 0m;
        }
    }
}

