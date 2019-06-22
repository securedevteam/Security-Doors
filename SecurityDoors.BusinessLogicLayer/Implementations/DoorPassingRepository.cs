using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public DoorPassingRepository(ApplicationContext context)
        {
            db = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<DoorPassing>> GetDoorsPassingListAsync()
        {
            return await db.DoorPassings.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<DoorPassing> GetDoorPassingByIdAsync(int id)
        {
            return await db.DoorPassings.FindAsync(id);
        }

        /// <inheritdoc/>
        public async Task CreateAsync(DoorPassing item)
        {
            await db.DoorPassings.AddAsync(item);
        }

        /// <inheritdoc/>
        public void Update(DoorPassing item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var doorPassing = await db.DoorPassings.FindAsync(id);

            if (doorPassing != null)
            {
                db.DoorPassings.Remove(doorPassing);
                await db.SaveChangesAsync();
            }
        }

        /// <inheritdoc/>
        public async Task SaveAsync(DoorPassing item)
        {
            if (item.Id <= 0)
            {
                await db.DoorPassings.AddAsync(item);
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
