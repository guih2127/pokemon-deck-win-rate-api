using System;
using System.Text.Json.Serialization;

namespace PokemonDeckWinRateAPI.ViewModel
{
    public class InsertMatchViewModel
    {
        public bool Win { get; set; }
        public bool FirstTurn { get; set; }
        public int UsedDeckId { get; set; }
        public int OpponentDeckId { get; set; }
        public DateTime Date { get; set; }
    }
}