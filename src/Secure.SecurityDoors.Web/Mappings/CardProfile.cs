using AutoMapper;
using Secure.SecurityDoors.Logic.Models;
using Secure.SecurityDoors.Web.ViewModels;

namespace Secure.SecurityDoors.Web.Mappings
{
    /// <summary>
    /// AutoMapper for mapping dto -> vm of Card type.
    /// </summary>
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CardDto, CardViewModel>();
        }
    }
}
