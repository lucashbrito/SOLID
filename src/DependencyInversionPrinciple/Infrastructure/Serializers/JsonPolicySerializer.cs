using DependencyInversionPrinciple.Core.Interfaces;
using DependencyInversionPrinciple.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace DependencyInversionPrinciple.Infrastructure.Serializers
{
    public class JsonPolicySerializer:IPolicySerializer
    {
        public Policy GetPolicyFromString(string policyString)
        {
            return JsonConvert.DeserializeObject<Policy>(policyString, new StringEnumConverter());
        }
    }
}
