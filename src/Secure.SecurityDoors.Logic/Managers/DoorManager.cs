using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Exceptions;
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

        public async Task AddAsync(DoorDto doorDto)
        {
            doorDto = doorDto ?? throw new ArgumentNullException(nameof(doorDto));

            var door = _mapper.Map<Door>(doorDto);
            await _applicationContext.Doors.AddAsync(door);
        }

        public async Task<IEnumerable<DoorDto>> GetAllAsync(
            DoorStatusType? statusFilter = default,
            LevelType? levelFilter = default)
        {
            var doors = await _applicationContext.Doors
                .GetDoorQuery(false)
                .ApplyFilterByStatus(statusFilter)
                .ApplyFilterByLevel(levelFilter)
                .ToListAsync();

            return !doors.Any()
                ? new List<DoorDto>()
                : _mapper.Map<IEnumerable<DoorDto>>(doors);
        }

        public async Task UpdateAsync(DoorDto doorDto)
        {
            doorDto = doorDto ?? throw new ArgumentNullException(nameof(doorDto));

            if (doorDto.Id <= 0)
            {
                throw new ArgumentException(nameof(doorDto));
            }

            var door = await _applicationContext.Doors.FindAsync(doorDto.Id);
            if (door is null)
            {
                throw new NotFoundException(nameof(doorDto));
            }

            door = _mapper.Map(doorDto, door);
            _applicationContext.Doors.Update(door);
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException(nameof(id));
            }

            var door = await _applicationContext.Doors.FindAsync(id);
            if (door is null)
            {
                throw new NotFoundException(nameof(door));
            }

            _applicationContext.Doors.Remove(door);
        }
    }
}
