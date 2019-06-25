using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple.ISP
{
    public class DefaultRatingContext: IRatingContext
    {
        public InterfaceSegregationPrinciple.RatingEngine Engine { get; set; }
        public string LoadPolicyFromUri(string uri)
        {
            throw new System.NotImplementedException();
        }

        public string LoadPolicyFromJsonString(string policyJson)
        {
            throw new System.NotImplementedException();
        }

        public InterfaceSegregationPrinciple.Policy GetPolicyFromJsonString(string policyJson)
        {
            throw new System.NotImplementedException();
        }

        public InterfaceSegregationPrinciple.Policy GetPolicyFromXmlString(string policyXml)
        {
            throw new System.NotImplementedException();
        }

        public Rater CreateRaterForPolicy(InterfaceSegregationPrinciple.Policy policy, IRatingContext context)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRating(decimal rating)
        {
            throw new System.NotImplementedException();
        }

        public void Log(string msg)
        {
            throw new System.NotImplementedException();
        }
    }
}
