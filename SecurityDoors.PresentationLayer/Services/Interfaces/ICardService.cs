using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

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
        List<CardViewModel> GetCards();

        /// <summary>
        /// Получить карточку.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Карточка.</returns>
        CardViewModel GetCardById(int id);

        /// <summary>
        /// Изменить карточку.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Карточка.</returns>
        CardEditModel EditCardById(int id);

        /// <summary>
        /// Удалить карточку.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        void DeleteCardById(int id);

        /// <summary>
        /// Сохранить карточку с сигнатурой CardViewModel.
        /// </summary>
        /// <param name="model">модель карточки для сохранения.</param>
        /// <returns>Карточка.</returns>
        CardViewModel SaveCard(CardViewModel model);

        /// <summary>
        /// Сохранить карточку с сигнатурой CardEditModel.
        /// </summary>
        /// <param name="model">Модель карточки для сохранения.</param>
        /// <returns>Карточка.</returns>
        CardViewModel SaveCard(CardEditModel model);
    }
}
