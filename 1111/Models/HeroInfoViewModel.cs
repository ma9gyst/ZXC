using Domain.Core.Entities;
using Infrastructure.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1111.ViewModels
{
    public class HeroInfoViewModel
    {
        public Hero Hero { get; set; }
        public List<Matchup> Matchups { get; set; }
        public List<Matchup> EfficientVersus { get; set; }
        public List<Matchup> InefficientVersus { get; set; }
    }
}
