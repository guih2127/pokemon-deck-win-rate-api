namespace PokemonDeckWinRateAPI.ViewModel
{
    public class GetDeckAndDeckStatusViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstPokemonExternalId { get; set; }
        public string SecondPokemonExternalId { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public double WinPercentage { get; set; }
    }
}