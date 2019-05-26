using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    /// <summary>
    /// Репозиторий дверь.
    /// </summary>
    public class DoorRepository : IDoorRepository
    {

        private ApplicationContext db;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DoorRepository()
        {
            db = new ApplicationContext();
        }

        /// <inheritdoc/>
        public IEnumerable<Door> GetDoorsList()
        {
            return db.Doors;
        }

        /// <inheritdoc/>
        public Door GetDoorById(int id)
        {
            return db.Doors.Find(id);
        }

        
        public void Create(Door item)
        {
            db.Doors.Add(item);
        }

        
        public void Update(Door item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// TODO: Дверь являет внешним ключем для таблицы DoorPassing, соответственно надо перед удалением почистить ссылки на дверь в DoorPassing, если они есть
        /// <inheritdoc/>
        public void Delete(int id)
        {
            Door door = db.Doors.Find(id);
            if (door != null)
            {
                db.Doors.Remove(door);
                db.SaveChanges();
            }
        }

        /// <inheritdoc/>
        public void Save(Door item)
        {
            if (item.Id == 0)
            {
                db.Doors.Add(item);
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
