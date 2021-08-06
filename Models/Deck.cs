using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PokemonDeckWinRateAPI.Models
{
    public class Deck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstPokemonExternalId { get; set; }
        public string SecondPokemonExternalId { get; set; }

        [JsonIgnore]
        public List<Match> MatchsPlayed { get; set; }

        [JsonIgnore]
        public List<Match> MatchsAgainst { get; set; }
    }
}