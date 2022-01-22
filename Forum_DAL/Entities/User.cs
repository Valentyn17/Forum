using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum_DAL.Entities
{
    public class User:IdentityUser
    {
        public UserProfile UserProfile { get; set; }
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
