using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Core.Entities.OpenDotaEntities
{
    public class Hero
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
        public string FormatedName { get; set; }
        //public string pictureUri { get; set; }
    }
}
