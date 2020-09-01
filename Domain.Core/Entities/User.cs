using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string IsVerified { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
