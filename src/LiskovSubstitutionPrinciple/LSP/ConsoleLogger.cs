using System;

namespace LiskovSubstitutionPrinciple.LSP
{
    public static class ConsoleLogger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
