using SecurityDoors.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityDoors.BusinessLogicLayer.Interfaces
{
    public interface ICardRepository : IDisposable
    {
        IEnumerable<Card> GetCardsList();
        Card GetCard(int id);
        void Create(Card item);
        void Update(Card item);
        void Delete(int id);
        void Save();
    }
}
