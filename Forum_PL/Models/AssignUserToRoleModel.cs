using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_PL.Models
{
    public class AssignUserToRoleModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string[] Roles { get; set; }
    }
}
