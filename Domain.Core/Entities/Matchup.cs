using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Core.Entities
{
    public class Matchup
    {
        
        public int Id { get; set; }
        public virtual Hero Hero { get; set; }
        public virtual Hero Enemy { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
    }
}
