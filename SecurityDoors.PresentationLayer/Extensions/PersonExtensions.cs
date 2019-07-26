using SecurityDoors.Core.Constants;
using SecurityDoors.Core.Enums;
using SecurityDoors.DataAccessLayer.Models;
using SecurityDoors.PresentationLayer.ViewModels;

namespace SecurityDoors.PresentationLayer.Extensions
{
    /// <summary>
    /// Методы расширения для Person.
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
            var gender = string.Empty;

            switch (model.Gender)
            {
                case (int)PersonGender.IsMale: { gender = PersonConstants.IsMale; } break;
                case (int)PersonGender.IsFemale: { gender = PersonConstants.IsFemale; } break;
            }

            return gender;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель PersonViewModel.</param>
        /// <returns>Статус.</returns>
        public static int ConvertGender(this PersonViewModel model)
        {
            var gender = 0;

            switch (model.Gender)
            {
                case PersonConstants.IsMale: { gender = (int)PersonGender.IsMale; } break;
                case PersonConstants.IsFemale: { gender = (int)PersonGender.IsFemale; } break;
            }

            return gender;
        }

        /// <summary>
        /// Конвертация статуса в int.
        /// </summary>
        /// <param name="model">модель PersonEditModel.</param>
        /// <returns>Статус.</returns>
        public static int ConvertGender(this PersonEditModel model)
        {
            var gender = 0;

            switch (model.Gender)
            {
                case PersonConstants.IsMale: { gender = (int)PersonGender.IsMale; } break;
                case PersonConstants.IsFemale: { gender = (int)PersonGender.IsFemale; } break;
            }

            return gender;
        }
    }
}
