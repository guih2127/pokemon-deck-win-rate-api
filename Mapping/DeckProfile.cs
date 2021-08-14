using AutoMapper;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.ViewModel;

namespace PokemonDeckWinRateAPI.Mapping
{
    public class DeckProfile : Profile
    {
        public DeckProfile()
        {
            CreateMap<Deck, GetDeckViewModel>().ReverseMap();
            CreateMap<Deck, InsertDeckViewModel>().ReverseMap();
            CreateMap<Deck, GetDeckAndDeckStatusViewModel>().ReverseMap();
        }
    }
}
