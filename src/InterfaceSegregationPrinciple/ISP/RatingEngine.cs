using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple.ISP
{
    public class RatingEngine
    {
        public decimal Rating { get; set; }

        public readonly ILoggerConsole _logger;

        private IRatingContext context;

        public void Rate()
        {
            context= new DefaultRatingContext();

            _logger.Log("Starting rate.");

            _logger.Log("Loading policy.");

            var policyJson = FilePolicySource.GetPolicyFromSource();

            var policy = JsonPolicySerializer.GetPolicyFromJsonString(policyJson);

            var rater = new RaterFactory().Create(policy, context);

            rater.Rate(policy);

            var rater2 = new RaterFactory().CreateByReflection(policy, context);

            rater2.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}
