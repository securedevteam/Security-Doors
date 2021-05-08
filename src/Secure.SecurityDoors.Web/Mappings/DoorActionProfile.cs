using AutoMapper;
using Secure.SecurityDoors.Logic.Models;
using Secure.SecurityDoors.Web.ViewModels;

namespace Secure.SecurityDoors.Web.Mappings
{
    /// <summary>
    /// AutoMapper for mapping dto -> vm of DoorAction type.
    /// </summary>
    public class DoorActionProfile : Profile
    {
        public DoorActionProfile()
        {
            CreateMap<DoorActionDto, DoorActionViewModel>();
        }
    }
}
