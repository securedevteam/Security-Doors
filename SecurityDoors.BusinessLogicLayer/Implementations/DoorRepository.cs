using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public DoorRepository(ApplicationContext context)
        {
            db = context;
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

        /// <inheritdoc/>
        public Door GetDoorByName(string item)
        {
            return db.Doors.FirstOrDefault(d => d.Name == item);
        }

        /// <inheritdoc/>
        [Obsolete]
        public void Create(Door item)
        {
            db.Doors.Add(item);
        }

        /// <inheritdoc/>
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
            if (item.Id <= 0)
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
