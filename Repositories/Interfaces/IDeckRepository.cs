using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Repositories.Interfaces
{
    public interface IDeckRepository
    {
        public Task<IEnumerable<Deck>> GetDecksAsync(PaginationFilterViewModel paginationViewModel = null);
        public Task<Deck> InsertDeckAsync(Deck deck);
        public Task<int> GetDecksCountAsync();
    }
}