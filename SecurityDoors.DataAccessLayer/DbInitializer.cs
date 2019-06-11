using SecurityDoors.DataAccessLayer.Models;
using System.Linq;

namespace SecurityDoors.DataAccessLayer
{
    /// <summary>
    /// Класс для заполнения данными пустую базу данных.
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Заполнение первоначальными данными.
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(ApplicationContext context)
        {
            #region Проверка на пустоту данных в базе данных.

            if (context.Cards.Any())
            {
                return;
            }

            if (context.Doors.Any())
            {
                return;
            }

            if (context.DoorPassings.Any())
            {
                return;
            }

            if (context.People.Any())
            {
                return;
            }

            #endregion

            
        }
    }
}
