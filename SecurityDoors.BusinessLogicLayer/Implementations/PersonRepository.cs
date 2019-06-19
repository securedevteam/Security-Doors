using Microsoft.EntityFrameworkCore;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public PersonRepository(ApplicationContext context)
        {
            db = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Person>> GetPeopleListAsync()
        {
            return await db.People.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await db.People.FindAsync(id);
        }

		/// <inheritdoc/>
		public async Task CreateAsync(Person item)
        {
            await db.People.AddAsync(item);
        }

        /// <inheritdoc/>
        public void Update(Person item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// TODO: Человек являет внешним ключем для таблицы DoorPassing, соответственно надо перед удалением почистить ссылки на него в DoorPassing, если они есть
        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var person = await db.People.FindAsync(id);

            if (person != null)
            {
                db.People.Remove(person);
				await db.SaveChangesAsync();
			}
		}

        /// <inheritdoc/>
        public async Task SaveAsync(Person item)
        {
            if (item.Id <= 0)
            {
                await db.People.AddAsync(item);
            }
            else
            {
                db.Entry(item).State = EntityState.Modified;
            }

            await db.SaveChangesAsync();
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
