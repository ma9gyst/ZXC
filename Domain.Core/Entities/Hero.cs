using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Core.Entities
{
    public class Hero
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocalizedName { get; set; }
        public string PrimaryAttr { get; set; }
        public string AttackType { get; set; }
        //public string[] Roles { get; set; }
        public string FormattedName { get; set; }
    }
}
