using System;

namespace SOLID.UI
{
    class Program
    {
        static void Main(string[] args)
        {

            var ratingEngine= new OpenClosedPrinciple.OCP.RatingEngine();

            ratingEngine.Rate();
        }
    }
}
