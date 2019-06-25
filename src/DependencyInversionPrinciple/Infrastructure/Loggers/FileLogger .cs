using System.IO;
using DependencyInversionPrinciple.Core.Interfaces;

namespace DependencyInversionPrinciple.Infrastructure.Loggers
{
    public  class FileLogger : ILoggerConsole
    {
        public void Log(string message)
        {
            using (var stream = File.AppendText("log.txt"))
            {
                stream.WriteLine(message);
                stream.Flush();
            }
        }
    }
}
