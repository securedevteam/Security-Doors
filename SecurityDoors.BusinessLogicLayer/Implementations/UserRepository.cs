using Microsoft.EntityFrameworkCore;
using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Threading.Tasks;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    /// <summary>
    /// Репозиторий для управления Identity.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext db;

        /// <summary>
        /// Конструктор.  
        /// </summary>
        public UserRepository(ApplicationContext context)
        {
            db = context;
        }

        /// <inheritdoc/>
        public async Task<bool> FindByNicknameAsync(string item)
        {
            var user = await db.Users.FirstOrDefaultAsync(c => c.Nickname == item);

            if (user != null)
            {
                return false;
            }

            return true;
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
