using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Forum_BLL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required, StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public string Role { get; set; }

    }
}
