﻿using Microsoft.EntityFrameworkCore;
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
        public Card GetCardById(int id)
        {
            return db.Cards.Find(id);
        }

        /// <inheritdoc/>
        public Card GetCardByUniqueNumber(string item)
        {
            return db.Cards.FirstOrDefault(c => c.UniqueNumber == item);
        }

        /// <inheritdoc/>
		public void Create(Card item)
        {
            db.Cards.Add(item);
        }

        /// <inheritdoc/>
        public void Update(Card item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <inheritdoc/>
        public void Delete(int id)
        {
            Card card = db.Cards.Find(id);
            if (card != null)
            {
                db.Cards.Remove(card);
                db.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public void Save(Card item)
        {
            if (item.Id <= 0)
            {
                db.Cards.Add(item);
            }
            else
            {
                db.Entry(item).State = EntityState.Modified;
            }

            db.SaveChanges();
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
