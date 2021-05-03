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
    public class DoorActionManager : IDoorActionManager
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _applicationContext;

        public DoorActionManager(
            IMapper mapper,
            ApplicationContext applicationContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        public async Task AddAsync(DoorActionDto doorActionDto)
        {
            doorActionDto = doorActionDto ?? throw new ArgumentNullException(nameof(doorActionDto));

            var doorAction = _mapper.Map<DoorAction>(doorActionDto);
            await _applicationContext.DoorActions.AddAsync(doorAction);
        }

        public async Task<IEnumerable<DoorActionDto>> GetAllAsync(
            DoorActionStatusType? filterDoorActionStatusType = default)
        {
            var doorActions = await _applicationContext.DoorActions
                .GetDoorActionQuery(false)
                .ApplyFilterByStatus(filterDoorActionStatusType)
                .ToListAsync();

            return !doorActions.Any()
                ? new List<DoorActionDto>()
                : _mapper.Map<IEnumerable<DoorActionDto>>(doorActions);
        }

        public async Task<DoorActionDto> GetByIdAsync(
            int id,
            DoorActionStatusType? filterDoorActionStatusType = default)
        {
            var doorAction = await _applicationContext.DoorActions
                .GetDoorActionQuery(false)
                .ApplyFilterByStatus(filterDoorActionStatusType)
                .SingleOrDefaultAsync(doorAction => doorAction.Id == id);

            return doorAction is null
                ? throw new NotFoundException(nameof(doorAction))
                : _mapper.Map<DoorActionDto>(doorAction);
        }
    }
}
