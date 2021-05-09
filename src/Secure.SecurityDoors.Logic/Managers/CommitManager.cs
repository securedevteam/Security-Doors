using Secure.SecurityDoors.Data.Contexts;
using Secure.SecurityDoors.Logic.Interfaces;
using System;
using System.Threading.Tasks;

namespace Secure.SecurityDoors.Logic.Managers
{
    public class CommitManager : ICommitManager
    {
        private readonly ApplicationContext _applicationContext;

        public CommitManager(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        public async Task SaveAsync()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
