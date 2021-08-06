using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.Repositories.Interfaces;
using PokemonDeckWinRateAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Services
{
    public class DeckService : IDeckService
    {
        private readonly IDeckRepository _deckRepository;

        public DeckService(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public async Task<IEnumerable<Deck>> GetDecksAsync()
        {
            return await _deckRepository.GetDecksAsync();
        }

        public async Task<Deck> InsertDeckAsync(Deck deck)
        {
            return await _deckRepository.InsertDeckAsync(deck);
        }
    }
}