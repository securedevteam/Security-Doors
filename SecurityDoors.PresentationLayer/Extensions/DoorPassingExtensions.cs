using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;

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
    }
}
