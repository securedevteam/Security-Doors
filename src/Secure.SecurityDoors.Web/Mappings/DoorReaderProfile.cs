using AutoMapper;
using Secure.SecurityDoors.Logic.Models;
using Secure.SecurityDoors.Web.ViewModels;

namespace Secure.SecurityDoors.Web.Mappings
{
    /// <summary>
    ///AutoMapper for mapping dto -> vm of DoorReader type.
    /// </summary>
    public class DoorReaderProfile : Profile
    {
        public DoorReaderProfile()
        {
            CreateMap<DoorReaderDto, DoorReaderViewModel>();
        }
    }
}
