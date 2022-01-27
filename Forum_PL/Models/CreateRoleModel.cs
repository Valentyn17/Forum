using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_PL.Models
{
    public class CreateRoleModel
    {
        [Required]
        [MinLength(2)]
        public string RoleName { get; set; }
    }
}
