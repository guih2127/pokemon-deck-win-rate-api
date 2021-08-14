using PokemonDeckWinRateAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        public Task<Match> InsertMatchAsync(Match match);
        public Task<IEnumerable<Match>> GetMatchsByUsedDeckIdAsync(int usedDeckId, int userId);
        public Task<IEnumerable<Match>> GetAllMatchesAsync();
    }
}