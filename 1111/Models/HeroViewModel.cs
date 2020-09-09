using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1111.Models
{
    public class HeroViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public string PrimaryAttr { get; set; }
        public string AttackType { get; set; }
        public string[] Roles { get; set; }
        public string FormattedName { get; set; }
    }
}
