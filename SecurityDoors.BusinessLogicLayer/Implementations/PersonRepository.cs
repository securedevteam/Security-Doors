using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private ApplicationContext db;

        /// <summary>
        /// Создать базу данных пользователей
        /// </summary>
        public PersonRepository()
        {
            db = new ApplicationContext();
        }

        /// <summary>
        /// Создать пользователя
        /// </summary>
        /// <param name="item"></param> элемент
        public void Create(Person item)
        {
            db.People.Add(item);
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id"></param> идентификатор пользователя
        public void Delete(int id)
        {
            Person person = db.People.Find(id);
            if (person != null)
            {
                db.People.Remove(person);
            }
        }

        /// <summary>
        ///  Получить коллекцию пользователей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetPeopleList()
        {
            return db.People;
        }

        /// <summary>
        /// Получить пользователя
        /// </summary>
        /// <param name="id"></param> идентификатор пользователя
        /// <returns></returns>
        public Person GetPerson(int id)
        {
            return db.People.Find(id);

        }

        /// <summary>
        ///  Сохранить изменения
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }

        /// <summary>
        /// Обновить пользователя
        /// </summary>
        /// <param name="item"></param> элемент
        public void Update(Person item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
