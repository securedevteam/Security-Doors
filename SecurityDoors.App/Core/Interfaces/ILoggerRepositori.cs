using SecurityDoors.App.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.App.Core.Interfaces
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
