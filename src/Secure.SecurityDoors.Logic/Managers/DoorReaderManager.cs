using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Models;
using Secure.SecurityDoors.Logic.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Managers
{
    /// <inheritdoc cref="IDoorReaderManager"/>
    public class DoorReaderManager : IDoorReaderManager
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _applicationContext;

        public DoorReaderManager(
            IMapper mapper,
            ApplicationContext applicationContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        public async Task<IEnumerable<DoorReaderDto>> GetAllAsync(
            IList<string> serialNumbers = default,
            params string[] includes)
        {
            var doors = await _applicationContext.DoorReaders
                .GetDoorReaderQuery(false)
                .Includes(includes)
                .ApplyFilterBySerialNumbers(serialNumbers)
                .ToListAsync();

            return !doors.Any()
                ? new List<DoorReaderDto>()
                : _mapper.Map<IEnumerable<DoorReaderDto>>(doors);
        }
    }
}
