using Microsoft.EntityFrameworkCore;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    public class CardRepository : ICardRepository
    {
        private ApplicationContext db;

        public CardRepository()
        {
            db = new ApplicationContext();
        }

        public void Create(Card item)
        {
            db.Cards.Add(item);
        }

        public void Delete(int id)
        {
            Card card = db.Cards.Find(id);
            if (card != null)
            {
                db.Cards.Remove(card);
            }
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

        public Card GetCard(int id)
        {
            return db.Cards.Find(id);
        }

        public IEnumerable<Card> GetCardsList()
        {
            return db.Cards;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Card item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
