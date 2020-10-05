using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public AppUser()
        {
            Pictures = new List<Picture>();
        }
        public ICollection<Picture> Pictures { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime Birthday { get; set; }
    }
}