using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<Door>> GetDoorsListAsync()
        {
            return await db.Doors.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Door> GetDoorByIdAsync(int id)
        {
            return await db.Doors.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task<Door> GetDoorByNameAsync(string item)
        {
            return await db.Doors.FirstOrDefaultAsync(d => d.Name == item);
        }

        /// <inheritdoc/>
        public async Task CreateAsync(Door item)
        {
            await db.Doors.AddAsync(item);
        }

        /// <inheritdoc/>
        public void Update(Door item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// TODO: Дверь являет внешним ключем для таблицы DoorPassing, соответственно надо перед удалением почистить ссылки на дверь в DoorPassing, если они есть
        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var door = await db.Doors.FindAsync(id);

            if (door != null)
            {
                db.Doors.Remove(door);
                await db.SaveChangesAsync();
            }
        }

        /// <inheritdoc/>
        public async Task SaveAsync(Door item)
        {
            if (item.Id <= 0)
            {
                await db.Doors.AddAsync(item);
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
