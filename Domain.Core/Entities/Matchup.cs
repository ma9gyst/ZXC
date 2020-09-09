using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class Matchup
    {
        public int Id { get; set; }
        public int HeroId { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
    }
}
