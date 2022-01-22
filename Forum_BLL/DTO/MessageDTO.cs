using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_BLL.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string Text { get; set; }
        public int TopicId { get; set; }
    }
}
