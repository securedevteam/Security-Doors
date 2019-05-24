using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPeopleList();
        Person GetPerson(int id);
        void Create(Person item);
        void Update(Person item);
        void Delete(int id);
        void Save();
    }
}
