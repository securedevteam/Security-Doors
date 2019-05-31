using SecurityDoors.Core.Logger.Interfaces;
using SecurityDoors.Core.Logger.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.Core.Infrastructure
{
    public class LoggerRepository : ILoggerRepository
    {
        static ConcurrentDictionary<string, LoggerItem> _loggers = new ConcurrentDictionary<string, LoggerItem>();

        public IEnumerable<LoggerItem> GetAll()
        {
            return _loggers.Values;
        }

        public void Add(LoggerItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _loggers[item.Key] = item;
        }

        public LoggerItem Find(string key)
        {
            LoggerItem item;
            _loggers.TryGetValue(key, out item);
            return item;
        }

        public LoggerItem Remove(string key)
        {
            LoggerItem item;
            _loggers.TryGetValue(key, out item);
            _loggers.TryRemove(key, out item);
            return item;
        }

        public void Update(LoggerItem item)
        {
            _loggers[item.Key] = item;
        }
    }
}
