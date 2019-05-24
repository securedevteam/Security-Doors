using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    public class DoorRepository : IDoorRepository
    {

        private ApplicationContext db;

        public DoorRepository()
        {
            db = new ApplicationContext();
        }

        public void Create(Door item)
        {
            db.Doors.Add(item);
        }

        public void Delete(int id)
        {
            Door door = db.Doors.Find(id);
            if (door != null)
            {
                db.Doors.Remove(door);
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

        public Door GetDoor(int id)
        {
            return db.Doors.Find(id);
        }

        public IEnumerable<Door> GetDoorsList()
        {
            return db.Doors;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Door item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
