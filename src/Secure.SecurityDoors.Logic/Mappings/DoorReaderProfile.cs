using AutoMapper;
using Secure.SecurityDoors.Data.Models;
using Secure.SecurityDoors.Logic.Models;

namespace Secure.SecurityDoors.Logic.Mappings
{
    /// <summary>
    /// AutoMapper for mapping entity <-> dto of DoorReader type.
    /// </summary>
    public class DoorReaderProfile : Profile
    {
        public DoorReaderProfile()
        {
            CreateMap<DoorReader, DoorReaderDto>().ReverseMap();
        }
    }
}
