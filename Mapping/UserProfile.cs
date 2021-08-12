using AutoMapper;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.ViewModel;

namespace PokemonDeckWinRateAPI.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserViewModel>().ReverseMap();
            CreateMap<InsertUserViewModel, User>()
                .ReverseMap()
                .ForMember(x => x.ConfirmPassword, opt => opt.Ignore());
        }
    }
}