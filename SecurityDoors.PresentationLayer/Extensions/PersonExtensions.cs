using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.PresentationLayer.Extensions
{
    /// <summary>
    /// Методы расширени для Person.
    /// </summary>
    public static class PersonExtensions
    {
        /// <summary>
        /// Конвертация статуса в string.
        /// </summary>
        /// <param name="model">модель Person.</param>
        /// <returns>Статус.</returns>
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

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель PersonViewModel.</param>
        /// <returns>Статус.</returns>
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

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель PersonEditModel.</param>
        /// <returns>Статус.</returns>
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
