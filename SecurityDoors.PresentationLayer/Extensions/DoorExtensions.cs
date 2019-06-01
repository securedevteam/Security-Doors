using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.PresentationLayer.Extensions
{
    public static class DoorExtensions
    {
        /// <summary>
        /// Конвертация статуса в string.
        /// </summary>
        /// <param name="model">модель Card.</param>
        /// <returns>Статус.</returns>
        public static string ConvertStatus(this Door model)
        {
            var status = string.Empty;

            switch (model.Status)
            {
                case (int)DoorStatus.IsClosed: { status = DoorConstants.IsClosed; } break;
                case (int)DoorStatus.IsActive: { status = DoorConstants.IsActive; } break;
                case (int)DoorStatus.OnRepair: { status = DoorConstants.OnRepair; } break;
            }

            return status;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель DoorViewModel.</param>
        /// <returns>Статус.</returns>
        public static int ConvertStatus(this DoorViewModel model)
        {
            var status = 0;

            switch (model.Status)
            {
                case DoorConstants.IsClosed: { status = (int)DoorStatus.IsClosed; } break;
                case DoorConstants.IsActive: { status = (int)DoorStatus.IsActive; } break;
                case DoorConstants.OnRepair: { status = (int)DoorStatus.OnRepair; } break;
            }

            return status;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель DoorEditModel.</param>
        /// <returns>Статус.</returns>
        public static int ConvertStatus(this DoorEditModel model)
        {
            var status = 0;

            switch (model.Status)
            {
                case DoorConstants.IsClosed: { status = (int)DoorStatus.IsClosed; } break;
                case DoorConstants.IsActive: { status = (int)DoorStatus.IsActive; } break;
                case DoorConstants.OnRepair: { status = (int)DoorStatus.OnRepair; } break;
            }

            return status;
        }
    }
}
