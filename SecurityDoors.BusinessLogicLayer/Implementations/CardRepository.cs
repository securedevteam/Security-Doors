﻿using Microsoft.EntityFrameworkCore;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    /// <summary>
    /// Репозиторий карты.
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

        /// <summary>
        /// Получить коллекцию карт.
        /// </summary>
        /// <returns>Список карт.</returns>
        public IEnumerable<Card> GetCardsList()
        {
            return db.Cards;
        }

        /// <summary>
        /// Получить карту.
        /// </summary>
        /// <param name="id">идентификатор карты.</param>
        /// <returns>Карта.</returns>
        public Card GetCardById(int id)
        {
            return db.Cards.Find(id);
        }

        /// <summary>
        /// Создать карту.
        /// </summary>
        /// <param name="item">элемент.</param>
        public void Create(Card item)
        {
            db.Cards.Add(item);
        }

        /// <summary>
        ///  Обновить карту.
        /// </summary>
        /// <param name="item">элемент.</param>
        public void Update(Card item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Удалить карту.
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

        /// <summary>
        /// Сохранить изменения.
        /// </summary>
        /// <param name="item">элемент.</param>
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
