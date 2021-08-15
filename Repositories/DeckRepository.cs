using Microsoft.EntityFrameworkCore;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.Models.Context;
using PokemonDeckWinRateAPI.Repositories.Interfaces;
using PokemonDeckWinRateAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        private readonly PokemonDeckWinRateContext _context;

        public DeckRepository(PokemonDeckWinRateContext context)
        {
            _context = context;
        }

        public async Task<int> GetDecksCountAsync()
        {
            return await _context.Decks.CountAsync();
        }

        public async Task<IEnumerable<Deck>> GetDecksAsync(PaginationFilterViewModel paginationViewModel = null)
        {
            if (paginationViewModel != null)
            {
                var decksPaged = await _context.Decks
                   .Skip((paginationViewModel.PageNumber - 1) * paginationViewModel.PageSize)
                   .Take(paginationViewModel.PageSize)
                   .Include(d => d.MatchsAgainst)
                   .ToListAsync();

                return decksPaged;
            }

            var decks = await _context.Decks.
                Include(d => d.MatchsAgainst).
                ToListAsync();

            return decks;
        }

        public async Task<Deck> InsertDeckAsync(Deck deck)
        {
            var insertedDeck = await _context.Decks.AddAsync(deck);
            await _context.SaveChangesAsync();

            return insertedDeck.Entity;
        }
    }
}