using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public DeckRepository(PokemonDeckWinRateContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
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

        public async Task <IEnumerable<GetDeckAndDeckStatusViewModel>> GetBestDecksAsync(PaginationFilterViewModel paginationViewModel = null)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("Default")))
            {
                var query = @"SELECT 
                                d.*,
	                            SUM(CAST(m.Win AS INT)) AS MatchesWon,
                                COUNT(m.Id) - SUM(CAST(m.Win AS INT)) AS MatchesLost,
	                            (SUM(CAST(m.Win AS INT)) * 100 / COUNT(m.Id)) AS WinPercentage
                            FROM Decks d
                            LEFT JOIN Matchs m on d.Id = m.UsedDeckId
                            GROUP BY d.Id, d.Name, d.FirstPokemonExternalId, d.SecondPokemonExternalId
                            ORDER BY WinPercentage DESC, MatchesWon DESC
                            OFFSET @Offset ROWS FETCH NEXT @Next ROWS ONLY";

                var bestDecksStatus = await connection.QueryAsync<GetDeckAndDeckStatusViewModel>(query, paginationViewModel);

                return bestDecksStatus;
            }
        }

        public async Task<Deck> InsertDeckAsync(Deck deck)
        {
            var insertedDeck = await _context.Decks.AddAsync(deck);
            await _context.SaveChangesAsync();

            return insertedDeck.Entity;
        }
    }
}