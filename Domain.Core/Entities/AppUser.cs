using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public Picture Picture { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime Birthday { get; set; }
    }
}