using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum_PL.Models
{
    public class MessageModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }


        [Required]
        [MinLength(1)]
        public string Text { get; set; }
        [Required]
        public int TopicId { get; set; }
    }
}
