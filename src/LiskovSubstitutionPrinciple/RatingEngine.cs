using LiskovSubstitutionPrinciple.LSP;

namespace LiskovSubstitutionPrinciple
{
    public class RatingEngine
    {
        public decimal Rating { get; set; }

        public void Rate()
        {
            ConsoleLogger.Log("Starting rate.");

            ConsoleLogger.Log("Loading policy.");

            var policyJson = FilePolicySource.GetPolicyFromSource();

            var policy = JsonPolicySerializer.GetPolicyFromJsonString(policyJson);

            var rater2 = new RaterFactory().CreateByReflection(policy, new LSP.RatingEngine()); //new RaterFactory().CreateByReflection(policy, this);

            if (rater2 == null)
            {
                ConsoleLogger.Log("Uknown policy type");
            }
            else
            {
                rater2.Rate(policy);
            }

            ConsoleLogger.Log("Rating completed.");
        }
    }
}
