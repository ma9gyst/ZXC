using Domain.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.DTO
{
    public class MatchupDto
    {
        public int Id { get; set; }
        public HeroDto Hero { get; set; }
        [JsonProperty("hero_id")]
        public int HeroId { get; set; }
        [JsonProperty("games_played")]
        public int GamesPlayed { get; set; }
        [JsonProperty("wins")]
        public int Wins { get; set; }
    }
}
