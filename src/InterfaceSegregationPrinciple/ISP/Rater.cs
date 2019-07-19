using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple.ISP
{
    public abstract class Rater
    {
        protected readonly IRatingUpdater _ratingUpdater;
        protected readonly ILoggerConsole _logger;
        protected Rater(IRatingUpdater ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
            _logger = new ConsoleLogger();
        }

        public abstract void Rate(Policy policy);
    }
}
