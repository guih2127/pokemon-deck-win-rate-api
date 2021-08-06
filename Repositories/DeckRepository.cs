using Microsoft.EntityFrameworkCore;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.Models.Context;
using PokemonDeckWinRateAPI.Repositories.Interfaces;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Deck>> GetDecksAsync()
        {
            var decks = await _context.Decks.ToListAsync();
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