using Microsoft.AspNetCore.Mvc;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Models;
using Secure.SecurityDoors.Shared.Contracts.Requests;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageController : ControllerBase
    {
        private readonly ICommitManager _commitManager;
        private readonly ICardManager _cardManager;
        private readonly IDoorReaderManager _doorReaderManager;
        private readonly IDoorActionManager _doorActionManager;

        public PassageController(
            ICommitManager commitManager,
            ICardManager cardManager,
            IDoorReaderManager doorReaderManager,
            IDoorActionManager doorActionManager)
        {
            _commitManager = commitManager ?? throw new ArgumentNullException(nameof(commitManager));
            _cardManager = cardManager ?? throw new ArgumentNullException(nameof(cardManager));
            _doorReaderManager = doorReaderManager ?? throw new ArgumentNullException(nameof(doorReaderManager));
            _doorActionManager = doorActionManager ?? throw new ArgumentNullException(nameof(doorActionManager));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] PassageRequest request)
        {
            // TODO: to service and use cache

            var currentCardDto = (await _cardManager
                .GetAllAsync(uniqueNumbers: new string[] { request.CardUniqueNumber }))
                .FirstOrDefault();

            if (currentCardDto is null)
            {
                return NotFound();
            }

            var currentDoorReaderDto = (await _doorReaderManager
                .GetAllAsync(
                    serialNumbers: new string[] { request.DoorReaderSerialNumber },
                    includes: new string[] { nameof(DoorReader.Door) }))
                .FirstOrDefault();

            if (currentDoorReaderDto is null)
            {
                return NotFound();
            }

            var doorActionStatus = DoorActionStatusType.Success;

            if (currentCardDto.Status == CardStatusType.Locked)
            {
                doorActionStatus = DoorActionStatusType.Error;
            }

            if (currentDoorReaderDto.Door.Status != DoorStatusType.Active)
            {
                doorActionStatus = DoorActionStatusType.Error;
            }

            if (currentCardDto.Level < currentDoorReaderDto.Door.Level)
            {
                doorActionStatus = DoorActionStatusType.Denied;
            }

            var doorActionDto = new DoorActionDto
            {
                CardId = currentCardDto.Id,
                DoorReaderId = currentDoorReaderDto.Id,
                Status = doorActionStatus,
                TimeStamp = DateTime.Now,
            };

            await _doorActionManager.AddAsync(doorActionDto);
            await _commitManager.SaveAsync();

            return doorActionStatus != DoorActionStatusType.Success
                ? BadRequest()
                : Ok();
        }
    }
}
