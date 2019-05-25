using Microsoft.EntityFrameworkCore;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    /// <summary>
    ///  Репозиторий карты.
    /// </summary>
    public class CardRepository : ICardRepository
    {        
        private ApplicationContext db;

        /// <summary>
        ///  Конструктор.  
        /// </summary>
        public CardRepository()
        {
            db = new ApplicationContext();
        }

        /// <summary>
        ///  Создать карту.
        /// </summary>
        /// <param name="item">элемент.</param>
        public void Create(Card item)
        {
            db.Cards.Add(item);
        }

        /// <summary>
        ///  Удалить карту.
        /// </summary>
        /// <param name="id">идентификатор карты.</param>
        public void Delete(int id)
        {
            Card card = db.Cards.Find(id);
            if (card != null)
            {
                db.Cards.Remove(card);
            }
        }

        private bool disposed = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
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

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///  Получить карту.
        /// </summary>
        /// <param name="id">идентификатор карты.</param>
        /// <returns></returns>
        public Card GetCard(int id)
        {
            return db.Cards.Find(id);
        }

        /// <summary>
        ///  Получить коллекцию карт.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Card> GetCardsList()
        {
            return db.Cards;
        }

        /// <summary>
        ///  Сохранить изменения.
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }

        /// <summary>
        ///  Обновить карту.
        /// </summary>
        /// <param name="item">элемент.</param>
        public void Update(Card item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
