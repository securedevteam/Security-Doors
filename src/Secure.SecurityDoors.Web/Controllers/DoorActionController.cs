using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Helpers;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Models;
using Secure.SecurityDoors.Web.Attributes;
using Secure.SecurityDoors.Web.Constants;
using Secure.SecurityDoors.Web.Services;
using Secure.SecurityDoors.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Web.Controllers
{
    public class DoorActionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ICardManager _cardManager;
        private readonly IDoorActionManager _doorActionManager;
        private readonly IReportService _reportService;
        private readonly RazorViewToStringRenderer _razorViewEngine;

        public DoorActionController(
            IMapper mapper,
            UserManager<User> userManager,
            ICardManager cardManager,
            IDoorActionManager doorActionManager,
            IReportService reportService,
            RazorViewToStringRenderer razorViewEngine)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _cardManager = cardManager ?? throw new ArgumentNullException(nameof(cardManager));
            _doorActionManager = doorActionManager ?? throw new ArgumentNullException(nameof(doorActionManager));
            _reportService = reportService ?? throw new ArgumentNullException(nameof(reportService));
            _razorViewEngine = razorViewEngine ?? throw new ArgumentNullException(nameof(razorViewEngine));
        }

        [Authorize]
        public async Task<IActionResult> List(DateTime? dateFilter, int? page)
        {
            const int defaultPage = 1;
            const int pageSize = 10;

            var pageFilter = new PageHelper
            {
                Page = page ?? defaultPage,
                PageSize = pageSize,
            };

            var user = await _userManager.GetUserAsync(User);

            var personCardIds = (await _cardManager.GetAllAsync(
                employeeIds: new string[] { user.Id }))
                .Select(cardDto => cardDto.Id)
                .ToArray();

            var doorActionDtosByPerson = (await _doorActionManager.GetAllAsync(
                pageFilter: pageFilter,
                dateFilter: dateFilter,
                cardIds: personCardIds,
                includes: new string[]
                {
                    nameof(DoorActionDto.Card),
                    nameof(DoorActionDto.DoorReader),
                    nameof(DoorReader.Door)
                }))
                .OrderBy(doorActionDto => doorActionDto.TimeStamp);

            return View(new DoorActionIndexViewModel
            {
                DoorActionViewModels = _mapper.Map<IEnumerable<DoorActionViewModel>>(doorActionDtosByPerson),
                PageViewModel = new PageViewModel(
                    await _doorActionManager.GetTotalCountAsync(
                        dateFilter: dateFilter,
                        cardIds: personCardIds),
                    pageFilter.Page,
                    pageFilter.PageSize),
                DateFilter = dateFilter.HasValue
                    ? dateFilter.Value.ToString("yyyy-MM-dd")
                    : null
            });
        }

        [AuthorizeRoles(RoleConstant.Admin)]
        public IActionResult Report()
        {
            var users = _userManager.Users.ToList();
            ViewBag.Users = new SelectList(users, "Id", "Email");
            return View();
        }

        [AuthorizeRoles(RoleConstant.Admin)]
        [HttpPost]
        public async Task<IActionResult> GenerateReport(string userId, DateTime? start, DateTime? end)
        {
            IList<string> CheckUserId() =>
                userId is not null
                    ? new string[] { userId }
                    : Array.Empty<string>();

            var doorActionDtos = (await _doorActionManager.GetAllAsync(
                dateRangeFilter: new DateRangeHelper
                {
                    Start = start,
                    End = end,
                },
                userIds: CheckUserId(),
                includes: new string[]
                {
                    nameof(DoorActionDto.Card),
                    nameof(DoorActionDto.DoorReader),
                    nameof(DoorReader.Door)
                }))
                .OrderBy(doorActionDto => doorActionDto.TimeStamp);

            var reportTemplateViewModel = new ReportTemplateViewModel
            {
                DoorActionViewModels =
                    _mapper.Map<IEnumerable<DoorActionViewModel>>(doorActionDtos)
            };

            var html = await _razorViewEngine
                .RenderViewToStringAsync(
                    "Views/Report/Template.cshtml",
                        reportTemplateViewModel);

            return File(
                await _reportService.GeneratePdfAsync(html),
                "application/octet-stream",
                $"Report_{DateTime.Now}.pdf");
        }
    }
}
