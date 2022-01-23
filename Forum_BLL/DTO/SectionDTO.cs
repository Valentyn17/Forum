using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_BLL.DTO
{
    public class SectionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<int> TopicsIds { get; set; }
    }
}
