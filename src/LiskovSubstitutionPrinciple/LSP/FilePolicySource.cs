using System.IO;

namespace LiskovSubstitutionPrinciple.LSP
{
    public static class FilePolicySource
    {
        public static string GetPolicyFromSource()
        {
            return File.ReadAllText("policy.json");
        }
    }
}
