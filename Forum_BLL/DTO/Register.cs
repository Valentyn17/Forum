using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_BLL.DTO
{
    public class Register
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
