using Microsoft.EntityFrameworkCore;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    /// <summary>
    /// Репозиторий карта.
    /// </summary>
    public class CardRepository : ICardRepository
    {        
        private ApplicationContext db;

        /// <summary>
        /// Конструктор.  
        /// </summary>
        public CardRepository(ApplicationContext context)
        {
            db = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Card>> GetCardsListAsync()
        {
            return await db.Cards.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Card> GetCardByIdAsync(int id)
        {
            return await db.Cards.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task<Card> GetCardByUniqueNumberAsync(string item)
        {
            return await db.Cards.FirstOrDefaultAsync(c => c.UniqueNumber == item);
        }

        /// <inheritdoc/>
		public async Task CreateAsync(Card item)
        {
            await db.Cards.AddAsync(item);
        }

        /// <inheritdoc/>
        public void Update(Card item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            Card card = await db.Cards.FindAsync(id);

            if (card != null)
            {
                db.Cards.Remove(card);
                await db.SaveChangesAsync();
            }
        }

        /// <inheritdoc/>
        public async Task SaveAsync(Card item)
        {
            if (item.Id <= 0)
            {
                await db.Cards.AddAsync(item);
            }
            else
            {
                db.Entry(item).State = EntityState.Modified;
            }

            await db.SaveChangesAsync();
        }



        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        } 
    }
}
