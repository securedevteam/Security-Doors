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
    [Route("api/[controller]")]
    public class LoggerController : Controller
    {
        private readonly ILoggerRepository _loggerRepository;
        private readonly ILogger _logger;

        public LoggerController(ILoggerRepository loggerRepository,
            ILogger<LoggerController> logger)
        {
            _loggerRepository = loggerRepository;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<LoggerItem> GetAll()
        {
            using (_logger.BeginScope("Message {HoleValue}", DateTime.Now))
            {
                _logger.LogInformation(LoggingEvents.ListItems, "Listing all items");
                EnsureItems();
            }
            return _loggerRepository.GetAll();
        }

        [HttpGet("{id}", Name = "GetLogger")]
        
        public IActionResult GetById(string id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Getting item {ID}", id);
            var item = _loggerRepository.Find(id);
            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({ID}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] LoggerItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _loggerRepository.Add(item);
            _logger.LogInformation(LoggingEvents.InsertItem, "Item {ID} Created", item.Key);
            return CreatedAtRoute("GetLogger", new { controller = "Logger", id = item.Key }, item);
        }

        [HttpPut("{id}")]
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
            _logger.LogInformation(LoggingEvents.UpdateItem, "Item {ID} Updated", item.Key);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _loggerRepository.Remove(id);
            _logger.LogInformation(LoggingEvents.DeleteItem, "Item {ID} Deleted", id);
        }

        private void EnsureItems()
        {
            if (!_loggerRepository.GetAll().Any())
            {
                _logger.LogInformation(LoggingEvents.GenerateItems, "Generating sample items.");
                for (int i = 1; i < 11; i++)
                {
                    _loggerRepository.Add(new LoggerItem() { Name = "Item " + i });
                }
            }
        }
    }
}

