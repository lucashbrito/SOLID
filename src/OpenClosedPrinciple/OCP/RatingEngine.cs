using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace OpenClosedPrinciple.OCP
{
    public class RatingEngine
    {
        public decimal Rating { get; set; }


        public void Rate()
        {
            ConsoleLogger.Log("Starting rate.");

            ConsoleLogger.Log("Loading policy.");

            var policyJson = FilePolicySource.GetPolicyFromSource();

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson, new StringEnumConverter());

            var rater = new RaterFactory().Create(policy, this);

            rater.Rate(policy);

            var rater2 = new RaterFactory().CreateByReflection(policy, this);

            rater2.Rate(policy);

            ConsoleLogger.Log("Rating completed.");
        }
    }
}
