using DependencyInversionPrinciple.Core.Interfaces;

namespace DependencyInversionPrinciple.Infrastructure.Loggers
{
    public  class NullLogger : ILoggerConsole
    {
        public  void Log(string message)
        {
        }
    }
}
