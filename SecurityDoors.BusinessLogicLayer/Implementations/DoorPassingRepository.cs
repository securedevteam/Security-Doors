using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    /// <summary>
    /// Репозиторий проход.
    /// </summary>
    public class DoorPassingRepository : IDoorPassingRepository
    {

        private ApplicationContext db;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public DoorPassingRepository()
        {
            db = new ApplicationContext();
        }

        /// <inheritdoc/>
        public IEnumerable<DoorPassing> GetDoorsPassingList()
        {
            return db.DoorPassings;
        }

        /// <inheritdoc/>
        public DoorPassing GetDoorPassingById(int id)
        {
            return db.DoorPassings.Find(id);
        }

        /// <inheritdoc/>
        public void Create(DoorPassing item)
        {
            db.DoorPassings.Add(item);
        }

        /// <inheritdoc/>
        public void Update(DoorPassing item)
        {
            db.Entry(item).State = EntityState.Modified;
        }



        /// <inheritdoc/>
        public void Delete(int id)
        {
            DoorPassing doorPassing = db.DoorPassings.Find(id);
            if (doorPassing != null)
            {
                db.DoorPassings.Remove(doorPassing);
            }
        }

        /// <inheritdoc/>
        public void Save(DoorPassing item)
        {
            if (item.Id == 0)
            {
                db.DoorPassings.Add(item);
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
