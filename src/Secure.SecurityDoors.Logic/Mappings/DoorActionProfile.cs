using AutoMapper;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Models;

namespace Secure.SecurityDoors.Logic.Mappings
{
    /// <summary>
    /// AutoMapper for mapping entity <-> dto of DoorAction type.
    /// </summary>
    public class DoorActionProfile : Profile
    {
        public DoorActionProfile()
        {
            CreateMap<DoorAction, DoorActionDto>().ReverseMap();
        }
    }
}
