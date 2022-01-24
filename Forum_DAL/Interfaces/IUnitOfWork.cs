using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IMessageRepository MessageRepository { get; }
        ISectionRepository SectionRepository { get; }
        ITopicRepository TopicRepository { get; }
        IUserProfileRepository UserProfileRepository { get; }


        Task SaveAsync();
    }
}
