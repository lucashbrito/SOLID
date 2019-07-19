using DependencyInversionPrinciple.Core.Model;
using DependencyInversionPrinciple.Core.Raters;
using DependencyInversionPrinciple.Infrastructure.Loggers;
using DependencyInversionPrinciple.Infrastructure.PolicySources;
using DependencyInversionPrinciple.Infrastructure.Serializers;

namespace DependencyInversionPrinciple.UI
{
    public class Start
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();

            logger.Log("Ardalis Insurance Rating System Starting...");

            var engine = new RatingEngine(logger, new FilePolicySource(), new JsonPolicySerializer(), new RaterFactory(logger));

            engine.Rate();

            if (engine.Rating > 0)
            {
                logger.Log($"Rating: {engine.Rating}");
            }
            else
            {
                logger.Log("No rating produced.");
            }
        }
    }
}
