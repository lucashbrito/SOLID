using InterfaceSegregationPrinciple.Interfaces;

namespace InterfaceSegregationPrinciple.ISP
{
    public abstract class Rater
    {
        protected readonly IRatingUpdater _ratingUpdater;
        protected readonly ILoggerConsole _logger = new ConsoleLogger();
        protected Rater(IRatingUpdater ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
        }

        public abstract void Rate(Policy policy);
    }
}
