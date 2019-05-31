using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;

namespace SecurityDoors.PresentationLayer.Extensions
{
    public static class DoorPassingExtensions
    {
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
