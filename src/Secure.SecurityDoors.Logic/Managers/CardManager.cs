using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Data.Enums;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Exceptions;
using Secure.SecurityDoors.Logic.Interfaces;
using Secure.SecurityDoors.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Managers
{
    public class CardManager : ICardManager
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _applicationContext;

        public CardManager(
            IMapper mapper,
            ApplicationContext applicationContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        public async Task AddAsync(CardDto cardDto)
        {
            cardDto = cardDto ?? throw new ArgumentNullException(nameof(cardDto));

            var card = _mapper.Map<Card>(cardDto);
            await _applicationContext.Cards.AddAsync(card);
        }

        public async Task<IEnumerable<CardDto>> GetAllAsync(
            LevelType? whereLevelType = default,
            CardStatusType? whereCardStatusType = default)
        {
            var cardQuery = _applicationContext.Cards
                .AsNoTracking();

            if (whereLevelType.HasValue)
            {
                cardQuery = cardQuery.Where(card => card.Level == whereLevelType);
            }

            if (whereCardStatusType.HasValue)
            {
                cardQuery = cardQuery.Where(card => card.Status == whereCardStatusType);
            }

            var cards = await cardQuery.ToListAsync();
            if (!cards.Any())
            {
                return new List<CardDto>();
            }

            return _mapper.Map<IEnumerable<CardDto>>(cards);
        }

        public async Task UpdateAsync(CardDto cardDto)
        {
            cardDto = cardDto ?? throw new ArgumentNullException(nameof(cardDto));

            if (cardDto.Id == 0)
            {
                throw new ArgumentException(nameof(cardDto));
            }

            var card = await _applicationContext.Cards.FindAsync(cardDto.Id);
            if (card is null)
            {
                throw new NotFoundException(nameof(cardDto));
            }

            card = _mapper.Map(cardDto, card);
            _applicationContext.Cards.Update(card);
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException(nameof(id));
            }

            var card = await _applicationContext.Cards.FindAsync(id);
            if (card is null)
            {
                throw new NotFoundException(nameof(card));
            }

            _applicationContext.Cards.Remove(card);
        }
    }
}
