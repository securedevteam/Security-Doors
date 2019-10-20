using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Logger.Constants;
using SecurityDoors.Core.Logger.Events;
using SecurityDoors.PresentationLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.App.Controllers.API
{
    /// <summary>
    /// WebAPI контроллер для карточек.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private ServicesManager _serviceManager;
        private readonly ILogger _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
        public CardsController(DataManager dataManager, ILogger<DoorController> logger)
        {
            _serviceManager = new ServicesManager(dataManager);
            _logger = logger;
        }

        // GET: api/Cards
        [HttpGet]
        public async Task<IEnumerable<string>> GetCards()
        {
            var cardsUniqueNumbers = new List<string>();
            var models = await _serviceManager.Cards.GetCardsAsync();

            if (!models.Any())
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.ListItemsNotFound, CardLoggerConstants.CARDS_LIST_IS_EMPTY);

                return null;
            }

            _logger.LogInformation(CommonSuccessfulEvents.ListItems, CardLoggerConstants.CARDS_LIST_IS_NOT_EMPTY + models.Count + AppConstants.DOT);

            foreach (var item in models)
            {
                cardsUniqueNumbers.Add(item.UniqueNumber);
            }

            return cardsUniqueNumbers;
        }
    }
}
