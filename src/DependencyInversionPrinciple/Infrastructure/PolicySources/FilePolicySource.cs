using System.IO;
using DependencyInversionPrinciple.Core.Interfaces;

namespace DependencyInversionPrinciple.Infrastructure.PolicySources
{
    public class FilePolicySource : IPolicySource
    {
        public  string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}
