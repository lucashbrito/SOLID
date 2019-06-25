using InterfaceSegregationPrinciple.ISP;

namespace InterfaceSegregationPrinciple.Interfaces
{
    public interface IRatingContext : ILoggerConsole, IRatingUpdater
    {
        RatingEngine Engine { get; set; }

        string LoadPolicyFromUri(string uri);

        string LoadPolicyFromJsonString(string policyJson);

        Policy GetPolicyFromJsonString(string policyJson);

        Policy GetPolicyFromXmlString(string policyXml);

        Rater CreateRaterForPolicy(Policy policy, IRatingContext context);
    }
}
