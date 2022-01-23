using Forum_DAL.Entities;
using System.Collections.Generic;

namespace Forum_BLL.DTO
{
    public class TopicDTO
    {
        public int Id { get; set; }
       
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int SectionId { get; set; }
        
        public string UserId { get; set; }
        public ICollection<int> MessagesIds { get; set; }
    }
}