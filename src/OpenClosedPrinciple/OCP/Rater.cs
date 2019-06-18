namespace OpenClosedPrinciple.OCP
{
    public abstract class Rater
    {
        public Rater(RatingEngine engine)
        {
        }

        public abstract void Rate(Policy policy);
    }
}
