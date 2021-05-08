﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
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
            PageDto pageDto = default,
            DateTime? dateFilter = default,
            DoorActionStatusType? filterDoorActionStatusType = default,
            IList<int> cardIds = default,
            IList<int> doorIds = default,
            params string[] includes)
        {
            var doorActions = await _applicationContext.DoorActions
                .GetDoorActionQuery(false)
                .Includes(includes)
                .ApplyPagination(pageDto)
                .ApplyFilterByDate(dateFilter)
                .ApplyFilterByCardIds(cardIds)
                .ApplyFilterByDoorIds(doorIds)
                .ApplyFilterByStatus(filterDoorActionStatusType)
                .ToListAsync();

            return !doorActions.Any()
                ? new List<DoorActionDto>()
                : _mapper.Map<IEnumerable<DoorActionDto>>(doorActions);
        }

        public async Task<int> GetTotalCountAsync() =>
            await _applicationContext.DoorActions.CountAsync();
    }
}
