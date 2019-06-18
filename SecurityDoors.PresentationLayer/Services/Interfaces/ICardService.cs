using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с контроллером.
    /// </summary>
    interface ICardService
    {
        /// <summary>
        /// Получить карточки.
        /// </summary>
        /// <returns>Список карточек.</returns>
        Task<List<CardViewModel>> GetCardsAsync();

        /// <summary>
        /// Получить карточку.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Карточка.</returns>
        Task<CardViewModel> GetCardByIdAsync(int id);

        /// <summary>
        /// Изменить карточку.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Карточка.</returns>
        Task<CardEditModel> EditCardByIdAsync(int id);

        /// <summary>
        /// Удалить карточку.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        Task DeleteCardByIdAsync(int id);

        /// <summary>
        /// Сохранить карточку с сигнатурой CardViewModel.
        /// </summary>
        /// <param name="model">модель карточки для сохранения.</param>
        /// <returns>Карточка.</returns>
        Task<CardViewModel> SaveCardAsync(CardViewModel model);

        /// <summary>
        /// Сохранить карточку с сигнатурой CardEditModel.
        /// </summary>
        /// <param name="model">Модель карточки для сохранения.</param>
        /// <returns>Карточка.</returns>
        Task<CardViewModel> SaveCardAsync(CardEditModel model);
    }
}
