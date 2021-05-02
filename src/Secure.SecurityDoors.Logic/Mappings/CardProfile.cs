using AutoMapper;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Models;

namespace Secure.SecurityDoors.Logic.Mappings
{
    /// <summary>
    /// AutoMapper for mapping entity <-> dto of Card type.
    /// </summary>
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardDto>().ReverseMap();
        }
    }
}
