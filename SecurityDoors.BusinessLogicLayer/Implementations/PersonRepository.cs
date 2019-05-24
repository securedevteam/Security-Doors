using SecurityDoors.BusinessLogicLayer.Interfaces;
using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private ApplicationContext db;

        public PersonRepository()
        {
            db = new ApplicationContext();
        }
        public void Create(Person item)
        {
            db.People.Add(item);
        }

        public void Delete(int id)
        {
            Person person = db.People.Find(id);
            if (person != null)
            {
                db.People.Remove(person);
            }
        }

        public IEnumerable<Person> GetPeopleList()
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(int id)
        {
            throw new NotImplementedException();

        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Person item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
