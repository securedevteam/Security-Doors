using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    public class DoorPassingRepository : IDoorPassingRepository
    {

        private ApplicationContext db;

        public DoorPassingRepository()
        {
            db = new ApplicationContext();
        }

        public void Create(DoorPassing item)
        {
            db.DoorPassings.Add(item);
        }

        public void Delete(int id)
        {
            DoorPassing doorPassing = db.DoorPassings.Find(id);
            if (doorPassing != null)
            {
                db.DoorPassings.Remove(doorPassing);
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

        public DoorPassing GetDoorPassing(int id)
        {
            return db.DoorPassings.Find(id);
        }

        public IEnumerable<DoorPassing> GetDoorsPassingList()
        {
            return db.DoorPassings;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(DoorPassing item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
