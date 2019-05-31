using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.PresentationLayer.Extensions
{
    public static class PersonExtensions
    {
        public static string ConvertGender(this Person model)
        {
            var status = string.Empty;

            switch (model.Gender)
            {
                case (int)PersonGender.IsMale: { status = PersonConstants.IsMale; } break;
                case (int)PersonGender.IsFemale: { status = PersonConstants.IsFemale; } break;
            }

            return status;
        }

        public static int ConvertGender(this PersonViewModel model)
        {
            var status = 0;

            switch (model.Gender)
            {
                case PersonConstants.IsMale: { status = (int)PersonGender.IsMale; } break;
                case PersonConstants.IsFemale: { status = (int)PersonGender.IsFemale; } break;
            }

            return status;
        }

        public static int ConvertGender(this PersonEditModel model)
        {
            var status = 0;

            switch (model.Gender)
            {
                case PersonConstants.IsMale: { status = (int)PersonGender.IsMale; } break;
                case PersonConstants.IsFemale: { status = (int)PersonGender.IsFemale; } break;
            }

            return status;
        }
    }
}
