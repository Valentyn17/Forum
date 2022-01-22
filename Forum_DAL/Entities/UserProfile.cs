using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum_DAL.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        public virtual User User { get; set; }

    }
}
