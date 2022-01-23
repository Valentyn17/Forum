using System;
using System.Collections.Generic;
using System.Text;

namespace Forum_BLL.Validation
{
    public class ForumException : Exception
    {
        public ForumException()
        {
        }

        public ForumException(string message)
            : base(message)
        {
        }

        public ForumException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
