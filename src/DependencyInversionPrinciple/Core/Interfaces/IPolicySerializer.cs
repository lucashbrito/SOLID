using DependencyInversionPrinciple.Core.Model;

namespace DependencyInversionPrinciple.Core.Interfaces
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policyString);
    }
}
