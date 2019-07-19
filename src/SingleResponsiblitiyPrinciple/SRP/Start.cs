﻿using System;

namespace SingleResponsiblitiyPrinciple.SRP
{
    public class Start
    {
        public void Main()
        {
            Console.WriteLine("Insurance rating system starting...");

            var engine = new RatingEngine();

            engine.Rate();

            Console.WriteLine(engine.Rating > 0 ? $"Rating; {engine.Rating}" : "No rating produced.");
        }
    }
}
