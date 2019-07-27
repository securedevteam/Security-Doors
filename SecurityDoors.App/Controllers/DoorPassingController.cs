using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.Core.Extensions;
using SecurityDoors.Core.Logger.Constants;
using SecurityDoors.Core.Logger.Events;
using SecurityDoors.Core.Models;
using SecurityDoors.Core.Reporting;
using SecurityDoors.PresentationLayer;
using SecurityDoors.PresentationLayer.Paginations;
using SecurityDoors.PresentationLayer.ReportViewModels;
using SecurityDoors.PresentationLayer.ViewModels;
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
        public async Task<ActionResult> Index(int page = 1)
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

                int pageSize = 45;
                var count = models.Count;
                var items = models.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                var pageViewModel = new PageViewModel(count, page, pageSize);
                var viewModel = new DoorPassingIndexViewModel
                {
                    PageViewModel = pageViewModel,
                    DoorPassings = items
                };

                return View(viewModel);
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
        public async Task<IActionResult> CreatePDFReport(ReportDoorPassingViewModel report)
        {
            if (ModelState.IsValid)
            {
                var doorPassingModels = await _serviceManager.DoorPassings.GetDoorPassingsAsync();

                var models = doorPassingModels.Select(d =>
                                                      new DoorPassingModel
                                                      {
                                                          Id = d.Id,
                                                          PassingTime = d.PassingTime,
                                                          Status = d.Status,
                                                          Location = d.Location,
                                                          Comment = d.Comment,
                                                          Door = d.Door,
                                                          Card = d.Card
                                                      })
                                             .Where(s => s.PassingTime >= report.Start && s.PassingTime <= report.End)
                                             .ToList();

                var infoCard = "каточка не была указана";
                
                if (!string.IsNullOrWhiteSpace(report.Card))
                {
                    models = models.Where(d => d.Card == report.Card).ToList();
                    infoCard = $"уникальный номер карточки - {report.Card}";
                }

                if (models.Count > 0)
                {
                    var reportType = (report.Type).ConvertType();
                    var service = new CreateAndSendReportService(reportType);
                    var result = await service.RunServiceAsync(models, ReportType.IsDoorPassing, report.Header, report.Description, report.Footer, report.Email);

                    _logger.LogInformation(CommonSuccessfulEvents.GenerateItems, DoorPassingLoggerConstants.DOORPASSING_REPORT_DATA_FOUND);

                    var message = new MessageViewModel() { Message = $"{ReportDataConstants.REPORT_GENERATED} {report.Email}." };

                    return View("ReportResult", message);
                }
                else
                {
                    _logger.LogWarning(CommonUnsuccessfulEvents.GetItemNotFound, DoorPassingLoggerConstants.DOORPASSING_REPORT_DATA_NOT_FOUND);

                    var message = new MessageViewModel() { Message = $"{ReportDataConstants.REPORT_NOT_GENERATED} Указанные данные: дата и время - с {report.Start} по {report.End}, {infoCard}." };

                    return View("ReportResult", message);
                }  		
            }

            return RedirectToAction(nameof(Index));
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