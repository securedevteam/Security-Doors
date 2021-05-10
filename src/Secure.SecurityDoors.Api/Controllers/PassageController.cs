using Microsoft.AspNetCore.Mvc;
using Secure.SecurityDoors.Api.Contracts.Requests;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Models;
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
            // TODO: use messages for response
            // TODO: add filters SerialNumber

            var currentCard = (await _cardManager
                .GetAllAsync(uniqueNumbers: new string[] { request.CardUniqueNumber }))
                .FirstOrDefault();

            if (currentCard is null)
            {
                return NotFound();
            }

            var doorReaderDtos = await _doorReaderManager.GetAllAsync();

            var currentDoorReader = doorReaderDtos
                .FirstOrDefault(doorReaderDto =>
                    doorReaderDto.SerialNumber == request.DoorReaderSerialNumber);

            if (currentDoorReader is null)
            {
                return NotFound();
            }

            var doorActionStatus = DoorActionStatusType.Success;

            if (currentCard.Status == CardStatusType.Locked)
            {
                doorActionStatus = DoorActionStatusType.Error;
            }

            if (currentDoorReader.Door.Status != DoorStatusType.Active)
            {
                doorActionStatus = DoorActionStatusType.Error;
            }

            if (currentCard.Level < currentDoorReader.Door.Level)
            {
                doorActionStatus = DoorActionStatusType.Denied;
            }

            var doorActionDto = new DoorActionDto
            {
                CardId = currentCard.Id,
                DoorReaderId = currentDoorReader.Id,
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
