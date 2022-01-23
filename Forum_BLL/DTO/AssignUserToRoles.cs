using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_BLL.DTO
{
    public class AssignUserToRoles
    {
        public string Email { get; set; }
        public string[] Roles { get; set; }

    }
}
