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

        public async Task<GetDeckStatusViewModel> GetDeckStatusByDeckIdAsync(int deckId, int userId)
        {
            var matchesPlayed = await _matchRepository.GetMatchsByUsedDeckIdAsync(deckId, userId);

            if (matchesPlayed.Count() == 0)
            {
                return new GetDeckStatusViewModel { };
            }

            var deckBestMatch = (matchesPlayed.Where(m => m.Win).Count() != 0) ?
                matchesPlayed
                .Where(m => m.Win)
                .GroupBy(m => m.OpponentDeck)
                .OrderByDescending(m => m.Count())
                .First().Key : null;

            var deckWorstMatch = (matchesPlayed.Where(m => !m.Win).Count() != 0) ?
                matchesPlayed
                .Where(m => !m.Win)
                .GroupBy(m => m.OpponentDeck)
                .OrderByDescending(m => m.Count())
                .First().Key : null;

            var deckBestMatchWinPercentage = (deckBestMatch != null) ?
                matchesPlayed.Where(m => m.OpponentDeckId == deckBestMatch.Id && m.Win).Count() * 100 /
                matchesPlayed.Where(m => m.OpponentDeckId == deckBestMatch.Id).Count() : 0;

            var deckWorstMatchWinPercentage = (deckWorstMatch != null) ?
                matchesPlayed.Where(m => m.OpponentDeckId == deckWorstMatch.Id && m.Win).Count() * 100 /
                matchesPlayed.Where(m => m.OpponentDeckId == deckWorstMatch.Id).Count() : 0;

            return new GetDeckStatusViewModel
            {
                MatchesPlayed = matchesPlayed.Count(),
                MatchesWon = matchesPlayed.Where(m => m.Win).Count(),
                MatchesLost = matchesPlayed.Where(m => !m.Win).Count(),
                WinPercentage = (matchesPlayed.Where(m => m.Win).Count() * 100 / matchesPlayed.Count()),
                BestMatch = _mapper.Map<Deck, GetDeckViewModel>(deckBestMatch),
                WorstMatch = _mapper.Map<Deck, GetDeckViewModel>(deckWorstMatch),
                BestMatchWinPercentage = deckBestMatchWinPercentage,
                WorstMatchWinPercentage = deckWorstMatchWinPercentage
            };
        }

        public async Task<Deck> InsertDeckAsync(Deck deck)
        {
            return await _deckRepository.InsertDeckAsync(deck);
        }
    }
}