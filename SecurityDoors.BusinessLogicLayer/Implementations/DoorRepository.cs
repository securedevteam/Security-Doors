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

        /// <summary>
        ///  Создать базу данных дверей
        /// </summary>
        public DoorRepository()
        {
            db = new ApplicationContext();
        }

        /// <summary>
        /// Создать дверь  
        /// </summary>
        /// <param name="item"></param> элемент
        public void Create(Door item)
        {
            db.Doors.Add(item);
        }

        /// <summary>
        ///  Удалить дверь
        /// </summary>
        /// <param name="id"></param> идентификатор двери
        public void Delete(int id)
        {
            Door door = db.Doors.Find(id);
            if (door != null)
            {
                db.Doors.Remove(door);
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
        ///  Получить дверь
        /// </summary>
        /// <param name="id"></param> идентификатор двери
        /// <returns></returns>
        public Door GetDoor(int id)
        {
            return db.Doors.Find(id);
        }

        /// <summary>
        ///  Получить коллекцию дверей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Door> GetDoorsList()
        {
            return db.Doors;
        }

        /// <summary>
        ///  Сохранить изменения
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }

        /// <summary>
        ///  Обновить дверь
        /// </summary>
        /// <param name="item"></param> элемент
        public void Update(Door item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
