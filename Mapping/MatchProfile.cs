using AutoMapper;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.ViewModel;

namespace PokemonDeckWinRateAPI.Mapping
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, InsertMatchViewModel>().ReverseMap();
            CreateMap<Match, GetMatchViewModel>().ReverseMap();
            CreateMap<Match, GetDeckMatchViewModel>().ReverseMap();
        }
    }
}