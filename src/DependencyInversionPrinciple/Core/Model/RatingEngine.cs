using DependencyInversionPrinciple.Core.Interfaces;
using DependencyInversionPrinciple.Core.Raters;
using DependencyInversionPrinciple.Infrastructure.Loggers;
using DependencyInversionPrinciple.Infrastructure.PolicySources;
using DependencyInversionPrinciple.Infrastructure.Serializers;

namespace DependencyInversionPrinciple.Core.Model
{
    public class RatingEngine
    {
        private readonly ILoggerConsole _logger;
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;
        private readonly RaterFactory _raterFactory;

        public decimal Rating { get; set; }

        public RatingEngine(ILoggerConsole logger, IPolicySource policySource, IPolicySerializer policySerializer,
            RaterFactory raterFactory)
        {
            _logger = logger;
            _policySource = policySource;
            _policySerializer = policySerializer;
            _raterFactory = raterFactory;
        }

        public void Rate()
        {
            _logger.Log("Starting rate.");

            _logger.Log("Loading policy.");

            string policyJson = _policySource.GetPolicyFromSource();

            var policy = _policySerializer.GetPolicyFromString(policyJson);

            var rater = _raterFactory.Create(policy);

            Rating = rater.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}
