using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum_DAL.Entities
{
    public class User:IdentityUser
    {
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
