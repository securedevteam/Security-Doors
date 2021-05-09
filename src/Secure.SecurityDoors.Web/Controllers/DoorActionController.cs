using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Models;
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

        public DoorActionController(
            IMapper mapper,
            UserManager<User> userManager,
            ICardManager cardManager,
            IDoorActionManager doorActionManager)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _cardManager = cardManager ?? throw new ArgumentNullException(nameof(cardManager));
            _doorActionManager = doorActionManager ?? throw new ArgumentNullException(nameof(doorActionManager));
        }

        [Authorize]
        public async Task<IActionResult> List(DateTime? date, int? page)
        {
            const int defaultPage = 1;
            const int pageSize = 10;

            var pageDto = new PageDto
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
                pageDto: pageDto,
                dateFilter: date,
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
                    await _doorActionManager.GetTotalCountAsync(),
                    pageDto.Page,
                    pageDto.PageSize),
                Date = date ?? DateTime.Now,
            });
        }
    }
}
