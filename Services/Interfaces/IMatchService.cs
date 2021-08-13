using PokemonDeckWinRateAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Services.Interfaces
{
    public interface IMatchService
    {
        public Task<Match> InsertMatchAsync(Match match);
        Task<IEnumerable<Match>> GetMatchsByUsedDeckIdAsync(int usedDeckId, int userId);
    }
}