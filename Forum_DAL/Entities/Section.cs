using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_DAL.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}
