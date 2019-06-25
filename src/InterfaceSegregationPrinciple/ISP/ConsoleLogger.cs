using System;
using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple.ISP
{
    public  class ConsoleLogger: ILoggerConsole
    {
        public  void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
