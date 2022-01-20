using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Forum_DAL.Entities
{
    public class Section
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}
