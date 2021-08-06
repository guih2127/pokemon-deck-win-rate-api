using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.Repositories.Interfaces;
using PokemonDeckWinRateAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<IEnumerable<Match>> GetMatchsByUsedDeckIdAsync(int usedDeckId)
        {
            return await _matchRepository.GetMatchsByUsedDeckIdAsync(usedDeckId);
        }

        public async Task<Match> InsertMatchAsync(Match match)
        {
            return await _matchRepository.InsertMatchAsync(match);
        }
    }
}
