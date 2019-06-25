using System;
using DependencyInversionPrinciple.Core.Interfaces;

namespace DependencyInversionPrinciple.Infrastructure.Loggers
{
    public  class ConsoleLogger: ILoggerConsole
    {
        public  void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
