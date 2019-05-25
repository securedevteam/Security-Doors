﻿using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    /// <summary>
    ///  Репозиторий пользователя.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        private ApplicationContext db;

        /// <summary>
        ///  Конструктор.
        /// </summary>
        public PersonRepository()
        {
            db = new ApplicationContext();
        }

        /// <summary>
        ///  Создать пользователя.
        /// </summary>
        /// <param name="item">элемент.</param>
        public void Create(Person item)
        {
            db.People.Add(item);
        }

		/// <summary>
		///  Удалить пользователя.
		/// </summary>
		/// <param name="id">идентификатор.</param>
		/// TODO: Человек являет внешним ключем для таблицы DoorPassing, соответственно надо перед удалением почистить ссылки на него в DoorPassing, если они есть
		public void Delete(int id)
        {
            Person person = db.People.Find(id);
            if (person != null)
            {
                db.People.Remove(person);
            }
        }

        /// <summary>
        ///  Получить коллекцию пользователей.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetPeopleList()
        {
            return db.People;
        }

        /// <summary>
        ///  Получить пользователя.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns></returns>
        public Person GetPersonById(int id)
        {
            return db.People.Find(id);

        }

        /// <summary>
        ///  Сохранить изменения.
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }

        /// <summary>
        ///  Обновить пользователя.
        /// </summary>
        /// <param name="item">элемент.</param>
        public void Update(Person item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
