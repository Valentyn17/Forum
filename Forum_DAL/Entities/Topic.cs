using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_DAL.Entities
{
    public class Topic
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int  SectionId { get; set; }
        public int UserId { get; set; }
        public ICollection<Message> Messages{ get; set; }

        public Section Section { get; set; }
        public ApplicationUser User { get; set; }
    }
}
