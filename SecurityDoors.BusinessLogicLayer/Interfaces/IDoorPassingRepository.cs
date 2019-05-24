using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    public interface IDoorPassingRepository : IDisposable
    {
        IEnumerable<DoorPassing> GetDoorsPassingList();
        DoorPassing GetDoorPassing(int id);
        void Create(DoorPassing item);
        void Update(DoorPassing item);
        void Delete(int id);
        void Save();
    }
}
