using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_PL.Models
{
    public class TopicModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        public string Description { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string UserId { get; set; }
        public ICollection<int> MessagesIds { get; set; } = new List<int>();
    }
}
