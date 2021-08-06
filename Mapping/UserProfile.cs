using AutoMapper;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.ViewModel;

namespace PokemonDeckWinRateAPI.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Deck, GetDeckViewModel>().ReverseMap();
            CreateMap<Deck, InsertDeckViewModel>().ReverseMap();
        }
    }
}
