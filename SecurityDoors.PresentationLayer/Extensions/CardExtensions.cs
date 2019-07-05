using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.PresentationLayer.Extensions
{
    /// <summary>
    /// Методы расширени для Card.
    /// </summary>
    public static class CardExtensions
    {
        /// <summary>
        /// Конвертация статуса.
        /// </summary>
        /// <param name="model">модель Card.</param>
        /// <returns>Кортеж из статуса, уровня и нахождения.</returns>
        public static (string status, string level, string location) ConvertStatus(this Card model)
        {
            var result = (status: string.Empty, level: string.Empty, location: string.Empty);

            switch (model.Status)
            {
                case (int)CardStatus.IsClosed: { result.status = CardConstants.IsClosed; } break;
                case (int)CardStatus.IsActive: { result.status = CardConstants.IsActive; } break;
                case (int)CardStatus.IsLost: { result.status = CardConstants.IsLost; } break;
                case (int)CardStatus.IsSuspended: { result.status = CardConstants.IsSuspended; } break;
            }

            switch (model.Level)
            {
                case (int)CardLevels.IsGuest: { result.level = CardConstants.IsGuest; } break;
                case (int)CardLevels.IsIntern: { result.level = CardConstants.IsIntern; } break;
                case (int)CardLevels.IsEmployee: { result.level = CardConstants.IsEmployee; } break;
                case (int)CardLevels.IsAdministrator: { result.level = CardConstants.IsAdministrator; } break;
                case (int)CardLevels.IsManager: { result.level = CardConstants.IsManager; } break;
            }

            switch (model.Location)
            {
                case CardConstants.IsExit: { result.location = CardConstants.Exit; } break;
                case CardConstants.IsEntrance: { result.location = CardConstants.Entrance; } break;
            }

            return result;
        }

        /// <summary>
        /// Конвертация статуса.
        /// </summary>
        /// <param name="model">модель CardViewModel.</param>
        /// <returns>Кортеж из статуса, уровня и нахождения.</returns>
        public static (int status, int level, bool location) ConvertStatus(this CardViewModel model)
        {
            var result = (status: 0, level: 0, location: false);

            switch (model.Status)
            {
                case CardConstants.IsClosed: { result.status = (int)CardStatus.IsClosed; } break;
                case CardConstants.IsActive: { result.status = (int)CardStatus.IsActive; } break;
                case CardConstants.IsLost: { result.status = (int)CardStatus.IsLost; } break;
                case CardConstants.IsSuspended: { result.status = (int)CardStatus.IsSuspended; } break;
            }

            switch (model.Level)
            {
                case CardConstants.IsGuest: { result.level = (int)CardLevels.IsGuest; } break;
                case CardConstants.IsIntern: { result.level = (int)CardLevels.IsIntern; } break;
                case CardConstants.IsEmployee: { result.level = (int)CardLevels.IsEmployee; } break;
                case CardConstants.IsAdministrator: { result.level = (int)CardLevels.IsAdministrator; } break;
                case CardConstants.IsManager: { result.level = (int)CardLevels.IsManager; } break;
            }

            switch (model.Location)
            {
                case CardConstants.Exit: { result.location = CardConstants.IsExit; } break;
                case CardConstants.Entrance: { result.location = CardConstants.IsEntrance; } break;
            }

            return result;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель CardEditModel.</param>
        /// <returns>Статус.</returns>
        public static int ConvertStatus(this CardEditModel model)
        {
            var status = 0;

            switch (model.Status)
            {
                case CardConstants.IsClosed: { status = (int)CardStatus.IsClosed; } break;
                case CardConstants.IsActive: { status = (int)CardStatus.IsActive; } break;
                case CardConstants.IsLost: { status = (int)CardStatus.IsLost; } break;
                case CardConstants.IsSuspended: { status = (int)CardStatus.IsSuspended; } break;
            }

            return status;
        }
    }
}
