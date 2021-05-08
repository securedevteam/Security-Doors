using AutoMapper;
using Secure.SecurityDoors.Logic.Models;
using Secure.SecurityDoors.Web.ViewModels;

namespace Secure.SecurityDoors.Web.Mappings
{
    /// <summary>
    /// AutoMapper for mapping dto -> vm of Door type.
    /// </summary>
    public class DoorProfile : Profile
    {
        public DoorProfile()
        {
            CreateMap<DoorDto, DoorViewModel>();
        }
    }
}
