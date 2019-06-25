using System.IO;

namespace InterfaceSegregationPrinciple.ISP
{
    public static class FilePolicySource
    {
        public static string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}
