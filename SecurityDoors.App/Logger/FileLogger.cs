using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace SecurityDoors.App
{
    public class FileLogger : ILogger
    {
        private string filePath;
        private object _lock = new object();
        public FileLogger(string path)
        {
            filePath = path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
            throw new NotImplementedException();
        }      

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if(formatter != null)
            {
                lock (_lock)
                {
                    // TODO: Разобраться
                    //File.AppendAllText(filePath, formatter(state, exception) + Environment.NewLine);
                }
                Console.WriteLine();
            }
        }
    }
}
