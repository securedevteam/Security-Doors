using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Helpers;
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
            PageHelper pageFilter = default,
            DateTime? dateFilter = default,
            DateRangeHelper dateRangeFilter = default,
            IList<int> cardIds = default,
            IList<int> doorIds = default,
            IList<string> userIds = default,
            DoorActionStatusType? statusFilter = default,
            params string[] includes)
        {
            var doorActions = await _applicationContext.DoorActions
                .GetDoorActionQuery(false)
                .Includes(includes)
                .ApplyPagination(pageFilter)
                .ApplyFilterByDate(dateFilter)
                .ApplyFilterByDateRange(dateRangeFilter)
                .ApplyFilterByCardIds(cardIds)
                .ApplyFilterByDoorIds(doorIds)
                .ApplyFilterByUserIds(userIds)
                .ApplyFilterByStatus(statusFilter)
                .ToListAsync();

            return !doorActions.Any()
                ? new List<DoorActionDto>()
                : _mapper.Map<IEnumerable<DoorActionDto>>(doorActions);
        }

        public async Task<int> GetTotalCountAsync(
            DateTime? dateFilter = default,
            IList<int> cardIds = default) =>
                await _applicationContext.DoorActions
                .ApplyFilterByDate(dateFilter)
                .ApplyFilterByCardIds(cardIds)
                .CountAsync();
    }
}
