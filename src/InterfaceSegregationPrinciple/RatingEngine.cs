using InterfaceSegregationPrinciple.Interfaces;
using InterfaceSegregationPrinciple.ISP;

namespace InterfaceSegregationPrinciple
{
    public class RatingEngine
    {
        public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }

        public void Rate()
        {
            Context.Log("Starting rate.");

            Context.Log("Loading policy.");

            var policyJson = FilePolicySource.GetPolicyFromSource();

            var policy = JsonPolicySerializer.GetPolicyFromJsonString(policyJson);

            var rater2 = new RaterFactory().CreateByReflection(policy, Context); //new RaterFactory().CreateByReflection(policy, this);

            if (rater2 == null)
            {
                Context.Log("Uknown policy type");
            }
            else
            {
                rater2.Rate(policy);
            }

            Context.Log("Rating completed.");
        }
    }
}
