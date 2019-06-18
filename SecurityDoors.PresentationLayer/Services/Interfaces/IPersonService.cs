using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecurityDoors.PresentationLayer.Services.Interfaces
{
    interface IPersonService
    {
        /// <summary>
        /// Получить сотрудником.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        Task<List<PersonViewModel>> GetPeopleAsync();

        /// <summary>
        /// Получить сотрудника.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Сотрудник.</returns>
		Task<PersonViewModel> GetPersonByIdAsync(int id);

        /// <summary>
        /// Изменить сотрудника.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Сотрудник.</returns>
		Task<PersonEditModel> EditPersonByIdAsync(int id);

        /// <summary>
        /// Удалить сотрудника.
        /// </summary>
        /// <param name="id">идентификатор.</param>
		void DeletePersonById(int id);

        /// <summary>
        /// Сохранить сотрудника с сигнатурой PersonViewModel.
        /// </summary>
        /// <param name="model">модель сотрудника для сохранения.</param>
        /// <returns>Сотрудник.</returns>
		Task<PersonViewModel> SavePersonAsync(PersonEditModel model);

        /// <summary>
        /// Сохранить сотрудника с сигнатурой PersonEditModel.
        /// </summary>
        /// <param name="model">модель сотрудника для сохранения.</param>
        /// <returns>Сотрудник.</returns>
		Task<PersonViewModel> SavePersonAsync(PersonViewModel model);
    }
}
