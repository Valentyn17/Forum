using Forum_DAL.Context;
using Forum_DAL.Entities;
using Forum_DAL.Interfaces;
using Forum_DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        private IUserProfileRepository _userProfileRepository;

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

        public IUserProfileRepository UserProfileRepository
        {
            get 
            {
                if (_userProfileRepository == null)
                    _userProfileRepository = new UserProfileRepository(_forumDbContext);
                return _userProfileRepository;
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
        public async Task<int> SaveAsync()
        {
             return await _forumDbContext.SaveChangesAsync();

        }
    }
}
