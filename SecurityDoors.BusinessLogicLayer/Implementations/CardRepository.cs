﻿using Microsoft.EntityFrameworkCore;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    /// <summary>
    /// Репозиторий карт.
    /// </summary>
    public class CardRepository : ICardRepository
    {        
        private ApplicationContext db;

        /// <summary>
        /// Конструктор.  
        /// </summary>
        public CardRepository()
        {
            db = new ApplicationContext();
        }

        /// <inheritdoc/>
        public IEnumerable<Card> GetCardsList()
        {
            return db.Cards;
        }

        /// <inheritdoc/>
        public Card GetCardById(int id)
        {
            return db.Cards.Find(id);
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
            }
        }

        /// <inheritdoc/>
        public void Save(Card item)
        {
            if (item.Id == 0)
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

        public virtual void Dispose(bool disposing)
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
