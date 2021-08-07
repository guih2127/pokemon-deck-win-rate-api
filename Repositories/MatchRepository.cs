using Microsoft.EntityFrameworkCore;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.Models.Context;
using PokemonDeckWinRateAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly PokemonDeckWinRateContext _context;

        public MatchRepository(PokemonDeckWinRateContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Match>> GetMatchsByUsedDeckIdAsync(int usedDeckId)
        {
            var matches = await _context.Matchs
                .Where(m => m.UsedDeckId == usedDeckId)
                .Include(m => m.OpponentDeck)
                .OrderByDescending(m => m.Id)
                .ToListAsync();

            return matches;
        }

        public async Task<Match> InsertMatchAsync(Match match)
        {
            var matchToInsert = await _context.Matchs.AddAsync(match);
            await _context.SaveChangesAsync();

            var insertedMatch = await _context.Matchs
                .Where(m => m.Id == matchToInsert.Entity.Id)
                .Include(m => m.OpponentDeck)
                .Include(m => m.UsedDeck)
                .FirstOrDefaultAsync();

            return insertedMatch;
        }
    }
}