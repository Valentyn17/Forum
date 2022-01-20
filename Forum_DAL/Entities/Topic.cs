using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Forum_DAL.Entities
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Title { get; set; }
        [Required]
        [MinLength(5)]
        public string Description { get; set; }
        [Required]
        public int  SectionId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public ICollection<Message> Messages{ get; set; } = new List<Message>();

        public Section Section { get; set; }
        public User User { get; set; }
    }
}
