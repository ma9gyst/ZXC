using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.DTO
{
    public class Matchup
    {
        public int Id { get; set; }
        [JsonProperty("hero_id")]
        public int HeroId { get; set; }
        [JsonProperty("games_played")]
        public int GamesPlayed { get; set; }
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
