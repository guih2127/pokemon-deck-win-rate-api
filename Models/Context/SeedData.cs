using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PokemonDeckWinRateAPI.Models.Context
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<PokemonDeckWinRateContext>();
            context.Database.EnsureCreated();

            if (!context.Decks.Any())
            {
                context.Decks.Add(entity: new Deck() { FirstPokemonExternalId = "swshp-SWSH045", Name = "Eternatus VMAX" });
                context.SaveChanges();
            }
        }
    }
}
