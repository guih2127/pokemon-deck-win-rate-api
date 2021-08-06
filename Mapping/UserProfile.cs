using AutoMapper;
using PokemonDeckWinRateAPI.DTOs;
using PokemonDeckWinRateAPI.Models;

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
