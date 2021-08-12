using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokemonDeckWinRateAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        [JsonIgnore]
        public List<Match> MatchesPlayed { get; set; }
    }
}