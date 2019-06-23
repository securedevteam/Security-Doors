using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Logger.Constants;
using SecurityDoors.Core.Logger.Events;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.App.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorsController : ControllerBase
    {
        private ServicesManager _serviceManager;
        private readonly ILogger _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
        public DoorsController(DataManager dataManager, ILogger<DoorController> logger)
        {
            _serviceManager = new ServicesManager(dataManager);
            _logger = logger;
        }

        // GET: api/Doors
        [HttpGet]
        public async Task<IEnumerable<DoorViewModel>> GetDoors()
        {
            var models = await _serviceManager.Doors.GetDoorsAsync();

            if (models == null || models.Count == 0)
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.ListItemsNotFound, DoorLoggerConstants.DOORS_LIST_IS_EMPTY);
            }
            else
            {
                _logger.LogInformation(CommonSuccessfulEvents.ListItems, DoorLoggerConstants.DOORS_LIST_IS_NOT_EMPTY + models.Count + AppConstants.DOT);
            }

            return models;
        }
    }
}
