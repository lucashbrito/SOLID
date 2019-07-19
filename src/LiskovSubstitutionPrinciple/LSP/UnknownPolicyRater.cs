namespace LiskovSubstitutionPrinciple.LSP
{
   public class UnknownPolicyRater:Rater
    {
        public UnknownPolicyRater(RatingEngine engine) : base(engine)
        {
        }

        public override void Rate(Policy policy)
        {
           ConsoleLogger.Log("Unknown policy type");
        }
    }
}
