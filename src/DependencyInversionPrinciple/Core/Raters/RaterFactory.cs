using System;
using DependencyInversionPrinciple.Core.Interfaces;
using DependencyInversionPrinciple.Core.Model;
using DependencyInversionPrinciple.Infrastructure.Loggers;

namespace DependencyInversionPrinciple.Core.Raters
{
    public class RaterFactory
    {
        private readonly ILoggerConsole _logger;

        public RaterFactory(ILoggerConsole logger)
        {
            _logger = logger;

        }

        public Rater Create(Policy policy)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(_logger);

                case PolicyType.Land:
                    return new LandPolicyRater(_logger);

                case PolicyType.Life:
                    return new LifePolicyRater(_logger);

                case PolicyType.Flood:
                    return new FloodPolicyRater(_logger);
                default:
                    new ConsoleLogger().Log("Unknown policy type");
                    break;
            }

            return null;
        }

        public Rater CreateByReflection(Policy policy)
        {
            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType($"OpenClosedPrinciple.OCP.{policy.Type}PolicyRater"),
                    new object[] { });
            }
            catch (Exception e)
            {
                _logger.Log(e.Message);
                return null;
            }
        }
    }
}
