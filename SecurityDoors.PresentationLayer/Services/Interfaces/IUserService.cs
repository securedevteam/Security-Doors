using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Interfaces
{
    interface IUserService
    {
        /// <summary>
        /// Возможность пользователя создать аккаунт.
        /// </summary>
        /// <param name="item">псевдоним.</param>
        /// <returns>Результат операции.</returns>
        Task<bool> CanUserCreateAccountAsync(string item);
    }
}
