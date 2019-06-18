using System.IO;

namespace OpenClosedPrinciple.OCP
{
    public static class FilePolicySource
    {
        public static string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}
