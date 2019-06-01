using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;
using System;

namespace SecurityDoors.PresentationLayer.Extensions
{
    /// <summary>
    /// Методы расширени для Card.
    /// </summary>
    public static class CardExtensions
    {
        /// <summary>
        /// Конвертация статуса в string.
        /// </summary>
        /// <param name="model">модель Card.</param>
        /// <returns>Статус. Уровень. Нахождение.</returns>
        public static (string, string, string) ConvertStatus(this Card model)
        {
            var status = string.Empty;
            var level = string.Empty;
            var location = string.Empty;

            switch (model.Status)
            {
                case (int)CardStatus.IsClosed: { status = CardConstants.IsClosed; } break;
                case (int)CardStatus.IsActive: { status = CardConstants.IsActive; } break;
                case (int)CardStatus.IsLost: { status = CardConstants.IsLost; } break;
                case (int)CardStatus.IsSuspended: { status = CardConstants.IsSuspended; } break;
            }

            switch (model.Level)
            {
                case (int)CardLevels.IsGuest: { level = CardConstants.IsGuest; } break;
                case (int)CardLevels.IsEmployee: { level = CardConstants.IsEmployee; } break;
                case (int)CardLevels.IsAdministrator: { level = CardConstants.IsAdministrator; } break;
                case (int)CardLevels.IsManager: { level = CardConstants.IsManager; } break;
            }

            switch (model.Location)
            {
                case CardConstants.IsExit: { location = CardConstants.Exit; } break;
                case CardConstants.IsEntrance: { location = CardConstants.Entrance; } break;
            }

            var result = (string.Empty, string.Empty, string.Empty);

            result.Item1 = status;
            result.Item2 = level;
            result.Item3 = location;

            return result;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель CardViewModel.</param>
        /// <returns>Статус.</returns>
        public static (int, int, bool) ConvertStatus(this CardViewModel model)
        {
            var status = 0;
            var level = 0;
            var location = false;

            switch (model.Status)
            {
                case CardConstants.IsClosed: { status = (int)CardStatus.IsClosed; } break;
                case CardConstants.IsActive: { status = (int)CardStatus.IsActive; } break;
                case CardConstants.IsLost: { status = (int)CardStatus.IsLost; } break;
                case CardConstants.IsSuspended: { status = (int)CardStatus.IsSuspended; } break;
            }

            switch (model.Level)
            {
                case CardConstants.IsGuest: { status = (int)CardLevels.IsGuest; } break;
                case CardConstants.IsEmployee: { status = (int)CardLevels.IsEmployee; } break;
                case CardConstants.IsAdministrator: { status = (int)CardLevels.IsAdministrator; } break;
                case CardConstants.IsManager: { status = (int)CardLevels.IsManager; } break;
            }

            switch (model.Location)
            {
                case CardConstants.Exit: { location = CardConstants.IsExit; } break;
                case CardConstants.Entrance: { location = CardConstants.IsEntrance; } break;
            }

            var result = (0, 0, false);

            result.Item1 = status;
            result.Item2 = level;
            result.Item3 = location;

            return result;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель CardEditModel.</param>
        /// <returns>Статус.</returns>
        public static (int, int, bool) ConvertStatus(this CardEditModel model)
        {
            var status = 0;
            var level = 0;
            var location = false;

            switch (model.Status)
            {
                case CardConstants.IsClosed: { status = (int)CardStatus.IsClosed; } break;
                case CardConstants.IsActive: { status = (int)CardStatus.IsActive; } break;
                case CardConstants.IsLost: { status = (int)CardStatus.IsLost; } break;
                case CardConstants.IsSuspended: { status = (int)CardStatus.IsSuspended; } break;
            }

            switch (model.Level)
            {
                case CardConstants.IsGuest: { status = (int)CardLevels.IsGuest; } break;
                case CardConstants.IsEmployee: { status = (int)CardLevels.IsEmployee; } break;
                case CardConstants.IsAdministrator: { status = (int)CardLevels.IsAdministrator; } break;
                case CardConstants.IsManager: { status = (int)CardLevels.IsManager; } break;
            }

            switch (model.Location)
            {
                case CardConstants.Exit: { location = CardConstants.IsExit; } break;
                case CardConstants.Entrance: { location = CardConstants.IsEntrance; } break;
            }

            var result = (0, 0, false);

            result.Item1 = status;
            result.Item2 = level;
            result.Item3 = location;

            return result;
        }
    }
}
