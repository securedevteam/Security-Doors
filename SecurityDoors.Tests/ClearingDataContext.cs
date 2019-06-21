using SecurityDoors.DataAccessLayer.Models;

namespace SecurityDoors.Tests
{
    public class ClearingDataContext
    {
        private readonly ApplicationContext _context;

        public ClearingDataContext(ApplicationContext context)
        {
            _context = context;
        }

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
