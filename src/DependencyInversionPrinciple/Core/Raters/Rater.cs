using DependencyInversionPrinciple.Core.Interfaces;
using DependencyInversionPrinciple.Core.Model;
using DependencyInversionPrinciple.Infrastructure.Loggers;

namespace DependencyInversionPrinciple.Core.Raters
{
    public abstract class Rater
    {
        public ILoggerConsole Logger { get; set; }

        public Rater(ILoggerConsole logger)
        {
            Logger = logger;
        }

        public abstract decimal Rate(Policy policy);
    }
}
