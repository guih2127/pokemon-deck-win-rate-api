using PokemonDeckWinRateAPI.Models;
using System;

namespace PokemonDeckWinRateAPI.ViewModel
{
    public class GetDeckMatchViewModel
    {
        public int Id { get; set; }
        public bool Win { get; set; }
        public bool FirstTurn { get; set; }
        public DateTime Date { get; set; }
        public Deck OpponentDeck { get; set; }
    }
}