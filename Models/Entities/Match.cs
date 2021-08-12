using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PokemonDeckWinRateAPI.Models
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Win { get; set; }
        public bool FirstTurn { get; set; }
        public int UsedDeckId { get; set; }
        public int OpponentDeckId { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public Deck UsedDeck { get; set; }

        [JsonIgnore]
        public Deck OpponentDeck { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}