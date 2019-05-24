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

        /// <summary>
        ///  Создать базу данных проходов
        /// </summary>
        public DoorPassingRepository()
        {
            db = new ApplicationContext();
        }

        /// <summary>
        /// Создать проход  
        /// </summary>
        /// <param name="item"></param> элемент
        public void Create(DoorPassing item)
        {
            db.DoorPassings.Add(item);
        }

        /// <summary>
        /// Удалить проход
        /// </summary>
        /// <param name="id"></param> идентификатор прохода
        public void Delete(int id)
        {
            DoorPassing doorPassing = db.DoorPassings.Find(id);
            if (doorPassing != null)
            {
                db.DoorPassings.Remove(doorPassing);
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
        /// Получить проход 
        /// </summary>
        /// <param name="id"></param> иденитификатор прохода
        /// <returns></returns>
        public DoorPassing GetDoorPassing(int id)
        {
            return db.DoorPassings.Find(id);
        }

        /// <summary>
        /// Получить коллекцию
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DoorPassing> GetDoorsPassingList()
        {
            return db.DoorPassings;
        }

        /// <summary>
        /// Сохранить изменения в базе данных
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }

        /// <summary>
        /// Обновить проход
        /// </summary>
        /// <param name="item"></param> элемент
        public void Update(DoorPassing item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
