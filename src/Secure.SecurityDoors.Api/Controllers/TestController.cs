using Microsoft.AspNetCore.Mvc;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Interfaces;
using System;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Api.Controllers
{
    // (!) NOTICE: This module should only be used for data testing
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICardManager _cardManager;
        private readonly IDoorReaderManager _doorReaderManager;

        public TestController(
            ICardManager cardManager,
            IDoorReaderManager doorReaderManager)
        {
            _cardManager = cardManager ?? throw new ArgumentNullException(nameof(cardManager));
            _doorReaderManager = doorReaderManager ?? throw new ArgumentNullException(nameof(doorReaderManager));
        }

        [HttpGet("cards")]
        public async Task<IActionResult> GetCardsAsync() =>
            Ok(await _cardManager.GetAllAsync());

        [HttpGet("doorreaders")]
        public async Task<IActionResult> GetDoorReadersAsync() =>
            Ok(await _doorReaderManager.GetAllAsync(
                includes: new string[] { nameof(DoorReader.Door) }));
    }
}
