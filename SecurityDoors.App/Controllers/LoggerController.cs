using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.Core.Logger;
using SecurityDoors.Core.Logger.Interfaces;
using SecurityDoors.Core.Logger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.App.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILoggerRepository _loggerRepository;
        private readonly ILogger _logger;

        public LoggerController(ILoggerRepository loggerRepository,
           ILoggerFactory logger)
        {
            _loggerRepository = loggerRepository;
            _logger = logger.CreateLogger("SecurityDoors.App.Controllers.LoggerController");
        }

        public IEnumerable<LoggerItem> GetAll()
        {
            using (_logger.BeginScope("Message {HoleValue}", DateTime.Now))
            {
                _logger.LogWarning(LoggingEvents.ListItems, "Listing all items");
                EnsureItems();
            }
            return _loggerRepository.GetAll();
        }
        
        public IActionResult GetById(string id)
        {
            _logger.LogError(LoggingEvents.GetItem, "Getting item {ID}", id);
            var item = _loggerRepository.Find(id);
            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({ID}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(item);
        }

        public IActionResult Create([FromBody] LoggerItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _loggerRepository.Add(item);
            _logger.LogError(LoggingEvents.InsertItem, "Item {ID} Created", item.Key);
            _logger.LogWarning(LoggingEvents.InsertItem, "Item {ID} Created", item.Key);
            return CreatedAtRoute("GetLogger", new { controller = "Logger", id = item.Key }, item);
        }

        public IActionResult Update(string id, [FromBody] LoggerItem item)
        {
            if (item == null || item.Key != id)
            {
                return BadRequest();
            }

            var logger = _loggerRepository.Find(id);
            if (logger == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "Update({ID}) NOT FOUND", id);
                return NotFound();
            }

            _loggerRepository.Update(item);
            _logger.LogError(LoggingEvents.UpdateItem, "Item {ID} Updated", item.Key);
            return new NoContentResult();
        }

        public void Delete(string id)
        {
            _loggerRepository.Remove(id);
            _logger.LogError(LoggingEvents.DeleteItem, "Item {ID} Deleted", id);
            _logger.LogWarning(LoggingEvents.DeleteItem, "Item {ID} Deleted", id);
        }

        private void EnsureItems()
        {
            if (!_loggerRepository.GetAll().Any())
            {
                _logger.LogWarning(LoggingEvents.GenerateItems, "Generating sample items.");
                for (int i = 1; i < 11; i++)
                {
                    _loggerRepository.Add(new LoggerItem() { Name = "Item " + i });
                }
            }
        }
    }
}

