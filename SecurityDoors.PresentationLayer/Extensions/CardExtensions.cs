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
        /// Конвертация статуса в string.
        /// </summary>
        /// <param name="model">модель Card.</param>
        /// <returns>Статус.</returns>
        public static string ConvertStatus(this Card model)
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
        /// <param name="model">модель CardViewModel.</param>
        /// <returns>Статус.</returns>
        public static int ConvertStatus(this CardViewModel model)
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
