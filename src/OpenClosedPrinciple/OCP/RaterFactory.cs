using System;

namespace OpenClosedPrinciple.OCP
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            switch (policy.Type)
            {
                case PolicyType.Auto:
                    return new AutoPolicyRater(engine);

                case PolicyType.Land:
                    return new LandPolicyRater(engine);

                case PolicyType.Life:
                    return new LifePolicyRater(engine);

                case PolicyType.Flood:
                    return new FloodPolicyRater(engine);
                default:
                    ConsoleLogger.Log("Unknown policy type");
                    break;
            }

            return null;
        }

        public Rater CreateByReflection(Policy policy, RatingEngine engine)
        {
            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType($"OpenClosedPrinciple.OCP.{policy.Type}PolicyRater"),
                    new object[] { engine });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }
    }
}
