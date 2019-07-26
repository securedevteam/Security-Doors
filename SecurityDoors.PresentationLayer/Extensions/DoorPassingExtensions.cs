using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.PresentationLayer.Extensions
{
    /// <summary>
    /// Методы расширения для DoorPassing.
    /// </summary>
    public static class DoorPassingExtensions
    {
        /// <summary>
        /// Конвертация статуса и прохода.
        /// </summary>
        /// <param name="model">модель DoorPassing.</param>
        /// <returns>Кортеж из статуса и прохода.</returns>
        public static (string status, string location) ConvertStatus(this DoorPassing model)
        {
            var result = (status: string.Empty, location: string.Empty);

            switch (model.Status)
            {
                case (int)DoorPassingStatus.WithoutСontrol: { result.status = DoorPassingConstants.WithoutСontrol; } break;
                case (int)DoorPassingStatus.OnControl: { result.status = DoorPassingConstants.OnControl; } break;
                case (int)DoorPassingStatus.IsAnnul: { result.status = DoorPassingConstants.IsAnnul; } break;
            }

            switch (model.Location)
            {
                case CardConstants.IsExit: { result.location = DoorPassingConstants.Exit; } break;
                case CardConstants.IsEntrance: { result.location = DoorPassingConstants.Entrance; } break;
            }

            return result;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель DoorPassingEditModel.</param>
        /// <returns>Статус.</returns>
        public static (int status, bool location) ConvertStatus(this DoorPassingViewModel model)
        {
            var result = (status: 0, location: false);

            switch (model.Status)
            {
                case DoorPassingConstants.WithoutСontrol: { result.status = (int)DoorPassingStatus.WithoutСontrol; } break;
                case DoorPassingConstants.OnControl: { result.status = (int)DoorPassingStatus.OnControl; } break;
                case DoorPassingConstants.IsAnnul: { result.status = (int)DoorPassingStatus.IsAnnul; } break;
            }

            switch (model.Location)
            {
                case DoorPassingConstants.Exit: { result.location = CardConstants.IsExit; } break;
                case DoorPassingConstants.Entrance: { result.location = CardConstants.IsEntrance; } break;
            }

            return result;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель DoorPassingEditModel.</param>
        /// <returns>Статус.</returns>
        public static (int status, bool location) ConvertStatus(this DoorPassingEditModel model)
        {
            var result = (status: 0, location: false);

            switch (model.Status)
            {
                case DoorPassingConstants.WithoutСontrol: { result.status = (int)DoorPassingStatus.WithoutСontrol; } break;
                case DoorPassingConstants.OnControl: { result.status = (int)DoorPassingStatus.OnControl; } break;
                case DoorPassingConstants.IsAnnul: { result.status = (int)DoorPassingStatus.IsAnnul; } break;
            }

            switch (model.Location)
            {
                case DoorPassingConstants.Exit: { result.location = CardConstants.IsExit; } break;
                case DoorPassingConstants.Entrance: { result.location = CardConstants.IsEntrance; } break;
            }

            return result;
        }
    }
}
