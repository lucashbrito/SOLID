using System;
using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple.ISP
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, IRatingContext context)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(context);

                case PolicyType.Land:
                    return new LandPolicyRater(context);

                case PolicyType.Life:
                    return new LifePolicyRater(context);

                case PolicyType.Flood:
                    return new FloodPolicyRater(context);
                default:
                    new ConsoleLogger().Log("Unknown policy type");
                    break;
            }

            return null;
        }

        public Rater CreateByReflection(Policy policy, IRatingContext context)
        {
            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType($"OpenClosedPrinciple.OCP.{policy.Type}PolicyRater"),
                    new object[] { context });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
    }
}
