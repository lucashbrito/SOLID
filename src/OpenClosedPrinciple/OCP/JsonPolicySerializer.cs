
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenClosedPrinciple.OCP
{
    public static class JsonPolicySerializer
    {
        public static Policy GetPolicyFromJsonString(string jsonString)
        {
            return JsonConvert.DeserializeObject<Policy>(jsonString, new StringEnumConverter());
        }
    }
}
