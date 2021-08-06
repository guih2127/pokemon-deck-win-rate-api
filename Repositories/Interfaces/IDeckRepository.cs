using PokemonDeckWinRateAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Repositories.Interfaces
{
    public interface IDeckRepository
    {
        public Task<IEnumerable<Deck>> GetDecksAsync();
        public Task<Deck> InsertDeckAsync(Deck deck);
    }
}