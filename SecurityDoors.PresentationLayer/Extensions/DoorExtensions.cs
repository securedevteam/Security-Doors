using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.PresentationLayer.Extensions
{
    /// <summary>
    /// Методы расширения для Door.
    /// </summary>
    public static class DoorExtensions
    {
        /// <summary>
        /// Конвертация статуса в string.
        /// </summary>
        /// <param name="model">модель Card.</param>
        /// <returns>Статус.</returns>
        public static (string status, string level) ConvertStatus(this Door model)
        {
            var result = (status: string.Empty, level: string.Empty);

            switch (model.Status)
            {
                case (int)DoorStatus.IsClosed: { result.status = DoorConstants.IsClosed; } break;
                case (int)DoorStatus.IsActive: { result.status = DoorConstants.IsActive; } break;
                case (int)DoorStatus.OnRepair: { result.status = DoorConstants.OnRepair; } break;
            }

            switch (model.Level)
            {
                case (int)DoorLevel.IsCommon: { result.level = DoorConstants.IsCommon; } break;
                case (int)DoorLevel.IsSpecial: { result.level = DoorConstants.IsSpecial; } break;
                case (int)DoorLevel.IsGuarded: { result.level = DoorConstants.IsGuarded; } break;
            }

            return result;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель DoorViewModel.</param>
        /// <returns>Статус.</returns>
        public static (int status, int level) ConvertStatus(this DoorViewModel model)
        {
            var result = (status: 0, level: 0);

            switch (model.Status)
            {
                case DoorConstants.IsClosed: { result.status = (int)DoorStatus.IsClosed; } break;
                case DoorConstants.IsActive: { result.status = (int)DoorStatus.IsActive; } break;
                case DoorConstants.OnRepair: { result.status = (int)DoorStatus.OnRepair; } break;
            }

            switch (model.Level)
            {
                case DoorConstants.IsCommon: { result.level = (int)DoorLevel.IsCommon; } break;
                case DoorConstants.IsSpecial: { result.level = (int)DoorLevel.IsSpecial; } break;
                case DoorConstants.IsGuarded: { result.level = (int)DoorLevel.IsGuarded; } break;
            }

            return result;
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
