using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.Core.Logger.Constants;
using SecurityDoors.Core.Logger.Events;
using SecurityDoors.Core.Reporting;
using SecurityDoors.Core.Reporting.Implementations;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.App.Controllers
{
    /// <summary>
    /// Контроллер для работы с дверями.
    /// </summary>
    public class DoorPassingController: Controller
    {
        private ServicesManager _serviceManager;
        private readonly ILogger _logger;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием дверей.</param>
		public DoorPassingController(DataManager dataManager, ILogger<DoorPassingController> logger)
        {
            _serviceManager = new ServicesManager(dataManager);
            _logger = logger;
        }

        /// <summary>
        /// Главная страница со списком дверных проходов.
        /// </summary>
        /// <returns>Представление со списком дверных проходов.</returns>        
        [Authorize]
        public async Task<ActionResult> Index()
        {
            if (User.IsInRole("admin") || User.IsInRole("moderator") || User.IsInRole("user") || User.IsInRole("visitor"))
            {
                var models = await _serviceManager.DoorPassings.GetDoorPassingsAsync();

                if (models == null || models.Count == 0)
                {
                    _logger.LogWarning(CommonUnsuccessfulEvents.ListItemsNotFound, DoorPassingLoggerConstants.DOORPASSING_LIST_IS_EMPTY);
                }
                else
                {
                    _logger.LogInformation(CommonSuccessfulEvents.ListItems, DoorPassingLoggerConstants.DOORPASSING_LIST_IS_NOT_EMPTY + models.Count + AppConstants.DOT);
                }

                return View(models);
            }
            else
            {
                return View("Error");
            }
        }

        /// <summary>
        /// Изменение существующего прохода (POST).
        /// </summary>
        /// <param name="doorPassing">модель прохода.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreatePDFReport(ReportDataViewModel reportDataViewModel)
        {
            // TODO: Доделать сюда логгер

            var all = await _serviceManager.DoorPassings.GetDoorPassingsAsync();
            var models = all.Take(50).ToList();

            var service = new CreateAndSendReportService();
            var result = await service.RunServiceAsync(models, ReportType.IsDoorPassing);

            return null; // TODO: результат всего этого
        }

        /// <summary>
        /// Изменение существующего прохода.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Представление.</returns>
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _serviceManager.DoorPassings.EditDoorPassingByIdAsync(id);

            return View(model);
        }

        /// <summary>
        /// Изменение существующего прохода (POST).
        /// </summary>
        /// <param name="doorPassing">модель прохода.</param>
        /// <returns>Представление.</returns>
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(DoorPassingEditModel doorPassing)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation(CommonSuccessfulEvents.EditItem, DoorPassingLoggerConstants.DOORPASSING_IS_VALID + CommonLoggerConstants.MODEL_SUCCESSFULLY_UPDATED);

                await _serviceManager.DoorPassings.SaveCardAsync(doorPassing);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                _logger.LogWarning(CommonUnsuccessfulEvents.EditItemNotFound, DoorPassingLoggerConstants.DOORPASSING_IS_NOT_VALID);

                return View(doorPassing);
            }
        }
    }
}