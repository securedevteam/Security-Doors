using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.Tests
{
    /// <summary>
    /// Класс для очистки контекста InMemoryDatabase.
    /// </summary>
    public class ClearingDataContext
    {
        private readonly ApplicationContext _context;

        /// <summary>
        /// Конструктор с параметром.
        /// </summary>
        /// <param name="context">контекст.</param>
        public ClearingDataContext(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Очистить контекст.
        /// </summary>
        public void Clear()
        {
            foreach (var entity in _context.Cards)
            {
                _context.Cards.Remove(entity);
            }

            foreach (var entity in _context.Doors)
            {
                _context.Doors.Remove(entity);
            }

            foreach (var entity in _context.DoorPassings)
            {
                _context.DoorPassings.Remove(entity);
            }

            foreach (var entity in _context.People)
            {
                _context.People.Remove(entity);
            }

            _context.SaveChanges();
        }
    }
}
