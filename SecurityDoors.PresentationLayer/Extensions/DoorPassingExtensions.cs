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
        /// Конвертация статуса в string.
        /// </summary>
        /// <param name="model">статус в int.</param>
        /// <returns>Статус.</returns>
        public static string ConvertStatus(this int statusModel)
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

        /// <summary>
        /// Конвертация статуса в string.
        /// </summary>
        /// <param name="model">модель DoorPassing.</param>
        /// <returns>Статус.</returns>
        public static string ConvertStatus(this DoorPassing model)
        {
            var status = string.Empty;

            switch (model.Status)
            {
                case (int)CardStatus.IsClosed: { status = CardConstants.IsClosed; } break;
                case (int)CardStatus.IsActive: { status = CardConstants.IsActive; } break;
                case (int)CardStatus.IsLost: { status = CardConstants.IsLost; } break;
                case (int)CardStatus.IsSuspended: { status = CardConstants.IsSuspended; } break;
            }

            return status;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель DoorPassingEditModel.</param>
        /// <returns>Статус.</returns>
        public static int ConvertStatus(this DoorPassingEditModel model)
        {
            var status = 0;

            switch (model.Status)
            {
                case DoorPassingConstants.WithoutСontrol: { status = (int)DoorPassingStatus.WithoutСontrol; } break;
                case DoorPassingConstants.OnControl: { status = (int)DoorPassingStatus.OnControl; } break;
                case DoorPassingConstants.IsAnnul: { status = (int)DoorPassingStatus.IsAnnul; } break;
            }

            return status;
        }
    }
}
