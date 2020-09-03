using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class AppUser : IdentityUser<int>
    {   
       public string Picture { get; set; }
       public DateTime RegistrationDate { get; set; }
       public int Year { get; set; }
    }
}
