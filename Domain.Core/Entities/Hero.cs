using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class Hero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public string PrimaryAttr { get; set; }
        public string AttackType { get; set; }
        public List<Matchup> Matchups { get; set; } = new List<Matchup>();
        //public string[] Roles { get; set; }
        public string FormattedName { get; set; }
    }
}
