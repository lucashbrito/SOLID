using DependencyInversionPrinciple.Core.Interfaces;

namespace DependencyInversionPrinciple.Infrastructure.PolicySources
{
    public class StringPolicySource : IPolicySource
    {
        public string PolicyString { get; set; } = "";

        public string GetPolicyFromSource()
        {
            return PolicyString;
        }

        public string SetPolicytFromSource(string source)
        {
            PolicyString = source;

            return PolicyString;
        }
    }
}
