using Forum_DAL.Context;
using Forum_DAL.Interfaces;
using Forum_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ForumDbContext _forumDbContext;
        private IMessageRepository _messageRepository;
        private ISectionRepository _sectionRepository;
        private ITopicRepository _topicRepository;
        public UnitOfWork(ForumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }

        public IMessageRepository MessageRepository
        {
            get
            {
                if (_messageRepository == null)
                    _messageRepository = new MessageRepository(_forumDbContext);
                return _messageRepository;
            }
        }

        public ISectionRepository SectionRepository
        {
            get
            {
                if (_sectionRepository == null)
                    _sectionRepository = new SectionRepository(_forumDbContext);
                return _sectionRepository;
            }
        }
        public ITopicRepository TopicRepository
        {
            get
            {
                if (_topicRepository == null)
                    _topicRepository = new TopicRepository(_forumDbContext);
                return _topicRepository;
            }
        }
        public async Task SaveAsync()
        {
            return await _forumDbContext.SaveChangesAsync();

        }
    }
}
