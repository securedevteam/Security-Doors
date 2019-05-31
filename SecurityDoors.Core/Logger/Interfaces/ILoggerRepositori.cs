using SecurityDoors.Core.Logger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.Core.Logger.Interfaces
{
    public interface ILoggerRepository
    {
        void Add(LoggerItem item);
        IEnumerable<LoggerItem> GetAll();
        LoggerItem Find(string key);
        LoggerItem Remove(string key);
        void Update(LoggerItem item);
    }
}
