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
    public class DoorManager : IDoorManager
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _applicationContext;

        public DoorManager(
            IMapper mapper,
            ApplicationContext applicationContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        public async Task<IEnumerable<DoorDto>> GetAllAsync(
            DoorStatusType? statusFilter = default,
            LevelType? levelFilter = default)
        {
            var doors = await _applicationContext.Doors
                .GetDoorQuery(false)
                .Include(door => door.DoorReaders)
                .ToListAsync();

            return !doors.Any()
                ? new List<DoorDto>()
                : _mapper.Map<IEnumerable<DoorDto>>(doors);
        }
    }
}
