using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Services.Interfaces
{
    interface IPersonService
    {
        /// <summary>
        /// Получить сотрудником.
        /// </summary>
        /// <returns>Список сотрудников.</returns>
        List<PersonViewModel> GetPeople();

        /// <summary>
        /// Получить сотрудника.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Сотрудник.</returns>
		PersonViewModel GetPersonById(int id);

        /// <summary>
        /// Изменить сотрудника.
        /// </summary>
        /// <param name="id">идентификатор.</param>
        /// <returns>Сотрудник.</returns>
		PersonEditModel EditPersonById(int id);

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
		PersonViewModel SavePerson(PersonEditModel model);

        /// <summary>
        /// Сохранить сотрудника с сигнатурой PersonEditModel.
        /// </summary>
        /// <param name="model">модель сотрудника для сохранения.</param>
        /// <returns>Сотрудник.</returns>
		PersonViewModel SavePerson(PersonViewModel model);
    }
}
