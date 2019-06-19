namespace LiskovSubstitutionPrinciple.LSP
{
    public abstract class Rater
    {
        public Rater(RatingEngine engine)
        {
        }

        public abstract void Rate(Policy policy);
    }
}
