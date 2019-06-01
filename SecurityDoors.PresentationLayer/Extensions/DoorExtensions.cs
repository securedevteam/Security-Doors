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
        public static (string, string) ConvertStatus(this Door model)
        {
            var status = string.Empty;
            var level = string.Empty;

            switch (model.Status)
            {
                case (int)DoorStatus.IsClosed: { status = DoorConstants.IsClosed; } break;
                case (int)DoorStatus.IsActive: { status = DoorConstants.IsActive; } break;
                case (int)DoorStatus.OnRepair: { status = DoorConstants.OnRepair; } break;
            }

            switch (model.Level)
            {
                case (int)DoorLevel.IsCommon: { level = DoorConstants.IsCommon; } break;
                case (int)DoorLevel.IsSpecial: { level = DoorConstants.IsSpecial; } break;
                case (int)DoorLevel.IsGuarded: { level = DoorConstants.IsGuarded; } break;
            }

            var result = (string.Empty, string.Empty);

            result.Item1 = status;
            result.Item2 = level;

            return result;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель DoorViewModel.</param>
        /// <returns>Статус.</returns>
        public static (int, int) ConvertStatus(this DoorViewModel model)
        {
            var status = 0;
            var level = 0;

            switch (model.Status)
            {
                case DoorConstants.IsClosed: { status = (int)DoorStatus.IsClosed; } break;
                case DoorConstants.IsActive: { status = (int)DoorStatus.IsActive; } break;
                case DoorConstants.OnRepair: { status = (int)DoorStatus.OnRepair; } break;
            }

            switch (model.Level)
            {
                case DoorConstants.IsCommon: { level = (int)DoorLevel.IsCommon; } break;
                case DoorConstants.IsSpecial: { level = (int)DoorLevel.IsSpecial; } break;
                case DoorConstants.IsGuarded: { level = (int)DoorLevel.IsGuarded; } break;
            }

            var result = (0, 0);

            result.Item1 = status;
            result.Item2 = level;

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
