using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Forum_DAL.Entities
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        [Required]
        public string UserId { get; set; }
        
        [Required]
        [MinLength(5)]
        public string  Text { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public User User { get; set; }
    }
}