using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Services.Interfaces
{
    public interface IDeckService
    {
        public Task<IEnumerable<Deck>> GetDecksAsync();
        public Task<Deck> InsertDeckAsync(Deck deck);
        public Task<GetDeckStatusViewModel> GetDeckStatusByDeckIdAsync(int deckId);
    }
}