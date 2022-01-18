using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string  Text { get; set; }
        public ApplicationUser User { get; set; }
    }
}