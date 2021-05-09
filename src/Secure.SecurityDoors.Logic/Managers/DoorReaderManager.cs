using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Models;
using Secure.SecurityDoors.Logic.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Managers
{
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

        // TODO: tests
        public async Task<IEnumerable<DoorReaderDto>> GetAllAsync(
            DoorReaderType? typeFilter = default,
            DoorStatusType? doorStatusFilter = default,
            LevelType? doorlevelFilter = default,
            params string[] includes)
        {
            var doors = await _applicationContext.DoorReaders
                .GetDoorReaderQuery(false)
                .Includes(includes)
                .ApplyFilterByType(typeFilter)
                .ApplyFilterByDoorStatus(doorStatusFilter)
                .ApplyFilterByDoorLevel(doorlevelFilter)
                .ToListAsync();

            return !doors.Any()
                ? new List<DoorReaderDto>()
                : _mapper.Map<IEnumerable<DoorReaderDto>>(doors);
        }
    }
}
