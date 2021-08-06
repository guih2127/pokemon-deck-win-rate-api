using PokemonDeckWinRateAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Services.Interfaces
{
    public interface IDeckService
    {
        public Task<IEnumerable<Deck>> GetDecksAsync();
        public Task<Deck> InsertDeckAsync(Deck deck);
    }
}