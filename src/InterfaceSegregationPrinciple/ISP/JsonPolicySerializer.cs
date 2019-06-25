using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace InterfaceSegregationPrinciple.ISP
{
    public static class JsonPolicySerializer
    {
        public static Policy GetPolicyFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonString, new StringEnumConverter());
        }
    }
}
