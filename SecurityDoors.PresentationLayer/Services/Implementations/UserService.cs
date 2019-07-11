using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.PresentationLayer.Services.Interfaces;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DataManager _dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием.</param>
        public UserService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        /// <inheritdoc/>
        public async Task<bool> CanUserCreateAccountAsync(string item)
        {
            var result = await _dataManager.Users.FindByNicknameAsync(item);

            return result;
        }
    }
}
