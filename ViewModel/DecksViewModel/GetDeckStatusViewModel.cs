namespace PokemonDeckWinRateAPI.ViewModel
{
    public class GetDeckStatusViewModel
    {
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public double WinPercentage { get; set; }
        public GetDeckViewModel BestMatch { get; set; }
        public GetDeckViewModel WorstMatch { get; set; }
        public double BestMatchWinPercentage { get; set; }
        public double WorstMatchWinPercentage { get; set; }
    }
}