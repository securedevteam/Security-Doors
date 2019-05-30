using SecurityDoors.BusinessLogicLayer;
using SecurityDoors.DataAccessLayer.Constants;
using SecurityDoors.DataAccessLayer.Enums;
using SecurityDoors.PresentationLayer.ViewModels;
using System.Collections.Generic;

namespace SecurityDoors.PresentationLayer.Services
{
    /// <summary>
    /// Сервис для работы с контроллером.
    /// </summary>
	public class DoorPassingService
	{
		private DataManager dataManager;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="dataManager">менеджер для работы с репозиторием карточек.</param>
		public DoorPassingService(DataManager dataManager)
		{
			this.dataManager = dataManager;
		}

        #region Вспомогательные методы для смены статуса карточки для ViewModel

        private string ConvertStatus(int statusModel)
        {
            var status = string.Empty;

            switch (statusModel)
            {
                case (int)DoorPassingStatus.WithoutСontrol: { status = DoorPassingConstants.WithoutСontrol; } break;
                case (int)DoorPassingStatus.OnControl: { status = DoorPassingConstants.OnControl; } break;
                case (int)DoorPassingStatus.IsAnnul: { status = DoorPassingConstants.IsAnnul; } break;
            }

            return status;
        }

        #endregion

        /// <summary>
        /// Получить все проходы.
        /// </summary>
        /// <returns>Список проходов.</returns>
		public List<DoorPassingViewModel> GetDoorPassings()
		{
			var models = dataManager.DoorsPassing.GetDoorsPassingList();
			var viewModels = new List<DoorPassingViewModel>();

			foreach (var model in models)
			{
                var personModel = dataManager.People.GetPersonById(model.PersonId);
                var doorModel = dataManager.Doors.GetDoorById(model.DoorId);

                var status = ConvertStatus(model.Status);

                viewModels.Add(new DoorPassingViewModel()
				{
					Id = model.Id,
					Door = doorModel.Name,
					Person = $"{personModel.FirstName} {personModel.LastName} {personModel.SecondName}",
					PassingTime = model.PassingTime,
                    Status = status,
					Comment = model.Comment
				});
			}

			return viewModels;
		}
	}
}
