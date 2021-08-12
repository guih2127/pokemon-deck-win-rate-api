using Microsoft.EntityFrameworkCore;

namespace PokemonDeckWinRateAPI.Models.Context
{
    public class PokemonDeckWinRateContext : DbContext
    {
        public PokemonDeckWinRateContext(DbContextOptions<PokemonDeckWinRateContext> options) : base(options)
        {

        }

        public DbSet<Deck> Decks { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(m => m.OpponentDeck)
                .WithMany(d => d.MatchsAgainst);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.UsedDeck)
                .WithMany(d => d.MatchsPlayed);

            modelBuilder.Entity<User>()
                .HasMany(u => u.MatchesPlayed)
                .WithOne(m => m.User);
        }
    }
}