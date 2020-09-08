using Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1111.ViewModels
{
    public class HeroInfoViewModel
    {
        public List<MatchupDto> Matchups { get; set; }
        public HeroDto Hero { get; set; }
    }
}
