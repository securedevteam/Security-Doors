using Microsoft.EntityFrameworkCore;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    /// <summary>
    /// Репозиторий пользователь.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private ApplicationContext db;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public PersonRepository()
        {
            db = new ApplicationContext();
        }

        /// <inheritdoc/>
        public IEnumerable<Person> GetPeopleList()
        {
            return db.People;
        }

        /// <inheritdoc/>
        public Person GetPersonById(int id)
        {
            return db.People.Find(id);

        }

        /// <inheritdoc/>
        public void Create(Person item)
        {
            db.People.Add(item);
        }

        /// <inheritdoc/>
        public void Update(Person item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// TODO: Человек являет внешним ключем для таблицы DoorPassing, соответственно надо перед удалением почистить ссылки на него в DoorPassing, если они есть
        /// <inheritdoc/>
        public void Delete(int id)
        {
            Person person = db.People.Find(id);
            if (person != null)
            {
                db.People.Remove(person);
            }
        }

        /// <inheritdoc/>
        public void Save(Person item)
        {
            if (item.Id == 0)
            {
                db.People.Add(item);
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
