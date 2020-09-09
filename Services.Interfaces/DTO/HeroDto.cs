using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Infrastructure.Data.DTO
{
    public class HeroDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("localized_name")]
        public string LocalizedName { get; set; }
        [JsonProperty("primary_attr")]
        public string PrimaryAttr { get; set; }
        [JsonProperty("attack_type")]
        public string AttackType { get; set; }
        [JsonProperty("roles")]
        [NotMapped]
        public string[] Roles { get; set; }
        public string FormattedName { get; set; }
        //public string PictureUri { get; set; }
    }
}
