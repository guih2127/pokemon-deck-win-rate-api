using PokemonDeckWinRateAPI.Models;

namespace PokemonDeckWinRateAPI.ViewModel
{
    public class GetDeckMatchViewModel
    {
        public int Id { get; set; }
        public bool Win { get; set; }
        public bool FirstTurn { get; set; }
        public Deck OpponentDeck { get; set; }
    }
}