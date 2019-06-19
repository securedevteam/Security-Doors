using SecurityDoors.Core.Logger.Model;
using System.Collections.Generic;

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
