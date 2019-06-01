using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.PresentationLayer.Extensions
{
    /// <summary>
    /// Методы расширени для DoorPassing.
    /// </summary>
    public static class DoorPassingExtensions
    {
        /// <summary>
        /// Конвертация статуса и прохода.
        /// </summary>
        /// <param name="model">модель DoorPassing.</param>
        /// <returns>Кортеж из статуса и прохода.</returns>
        public static (string, string) ConvertStatus(this DoorPassing model)
        {
            var status = string.Empty;
            var location = string.Empty;

            switch (model.Status)
            {
                case (int)DoorPassingStatus.WithoutСontrol: { status = DoorPassingConstants.WithoutСontrol; } break;
                case (int)DoorPassingStatus.OnControl: { status = DoorPassingConstants.OnControl; } break;
                case (int)DoorPassingStatus.IsAnnul: { status = DoorPassingConstants.IsAnnul; } break;
            }

            switch (model.Location)
            {
                case CardConstants.IsExit: { location = DoorPassingConstants.Exit; } break;
                case CardConstants.IsEntrance: { location = DoorPassingConstants.Entrance; } break;
            }

            var result = (string.Empty, string.Empty);
            result.Item1 = status;
            result.Item2 = location;

            return result;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель DoorPassingEditModel.</param>
        /// <returns>Статус.</returns>
        public static (int, bool) ConvertStatus(this DoorPassingViewModel model)
        {
            var status = 0;
            var location = false;

            switch (model.Status)
            {
                case DoorPassingConstants.WithoutСontrol: { status = (int)DoorPassingStatus.WithoutСontrol; } break;
                case DoorPassingConstants.OnControl: { status = (int)DoorPassingStatus.OnControl; } break;
                case DoorPassingConstants.IsAnnul: { status = (int)DoorPassingStatus.IsAnnul; } break;
            }

            switch (model.Location)
            {
                case DoorPassingConstants.Exit: { location = CardConstants.IsExit; } break;
                case DoorPassingConstants.Entrance: { location = CardConstants.IsEntrance; } break;
            }

            var result = (0, false);
            result.Item1 = status;
            result.Item2 = location;

            return result;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель DoorPassingEditModel.</param>
        /// <returns>Статус.</returns>
        public static (int, bool) ConvertStatus(this DoorPassingEditModel model)
        {
            var status = 0;
            var location = false;

            switch (model.Status)
            {
                case DoorPassingConstants.WithoutСontrol: { status = (int)DoorPassingStatus.WithoutСontrol; } break;
                case DoorPassingConstants.OnControl: { status = (int)DoorPassingStatus.OnControl; } break;
                case DoorPassingConstants.IsAnnul: { status = (int)DoorPassingStatus.IsAnnul; } break;
            }

            switch (model.Location)
            {
                case DoorPassingConstants.Exit: { location = CardConstants.IsExit; } break;
                case DoorPassingConstants.Entrance: { location = CardConstants.IsEntrance; } break;
            }

            var result = (0, false);
            result.Item1 = status;
            result.Item2 = location;

            return result;
        }
    }
}
