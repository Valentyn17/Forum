using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_PL.Models
{
    public class SectionModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Name { get; set; }
        public ICollection<int> TopicsIds { get; set; } = new List<int>();
    }
}
