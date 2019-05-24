using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    public interface IDoorRepository : IDisposable
    {
        IEnumerable<Door> GetDoorsList();
        Door GetDoor(int id);
        void Create(Door item);
        void Update(Door item);
        void Delete(int id);
        void Save();
    }
}
