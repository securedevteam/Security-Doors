using AutoMapper;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Models;

namespace Secure.SecurityDoors.Logic.Mappings
{
    /// <summary>
    /// AutoMapper for mapping entity <-> dto of Door type.
    /// </summary>
    public class DoorProfile : Profile
    {
        public DoorProfile()
        {
            CreateMap<Door, DoorDto>().ReverseMap();
        }
    }
}
