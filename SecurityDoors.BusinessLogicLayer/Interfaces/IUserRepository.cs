﻿using System.Threading.Tasks;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    /// <summary>
    /// Интерфейс для класса UserRepository.
    /// </summary>
    interface IUserRepository
    {
        /// Проверка на существование выбранного псевдонима в системе.
        /// </summary>
        /// <param name="item">псевдоним пользователя.</param>
        /// <returns>Результат поиска.</returns>
        Task<bool> FindByNicknameAsync(string item);
    }
}
