using AutoMapper;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.Repositories.Interfaces;
using PokemonDeckWinRateAPI.Services.Interfaces;
using PokemonDeckWinRateAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Services
{
    public class DeckService : IDeckService
    {
        private readonly IDeckRepository _deckRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public DeckService(IDeckRepository deckRepository, IMatchRepository matchRepository, IMapper mapper)
        {
            _deckRepository = deckRepository;
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Deck>> GetDecksAsync()
        {
            return await _deckRepository.GetDecksAsync();
        }

        public async Task<DeckStatusViewModel> GetDeckStatusByDeckIdAsync(int deckId)
        {
            var matchesPlayed = await _matchRepository.GetMatchsByUsedDeckIdAsync(deckId);

            return new DeckStatusViewModel
            {
                MatchesPlayed = matchesPlayed.Count(),
                MatchesWon = matchesPlayed.Where(m => m.Win).Count(),
                MatchesLost = matchesPlayed.Where(m => !m.Win).Count(),
                WinPercentage = (matchesPlayed.Where(m => m.Win).Count() * 100 / matchesPlayed.Count())
            };
        }

        public async Task<Deck> InsertDeckAsync(Deck deck)
        {
            return await _deckRepository.InsertDeckAsync(deck);
        }
    }
}