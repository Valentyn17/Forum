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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UnitOfWork(ForumDbContext forumDbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _forumDbContext = forumDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
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
             await _forumDbContext.SaveChangesAsync();

        }
    }
}
