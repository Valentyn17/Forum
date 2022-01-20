﻿using Forum_DAL.Context;
using Forum_DAL.Entities;
using Forum_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ForumDbContext _forumDbContext;

        public TopicRepository(ForumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }
        public async Task AddAsync(Topic entity)
        {
            await _forumDbContext.Topics.AddAsync(entity);
        }

        public async Task Delete(Topic entity)
        {
            var element = await _forumDbContext.Topics.Include(x=>x.Messages).FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (element != null)
            {
                _forumDbContext.Topics.Remove(element);
            }
        }

        public async Task DeletebyIdAsync(int id)
        {
            var element = await _forumDbContext.Topics.Include(x => x.Messages).FirstOrDefaultAsync(x => x.Id == id);
            if (element != null)
            {
                _forumDbContext.Topics.Remove(element);
            }
        }

        public IEnumerable<Topic> FindAllWithDetails()
        {
            return _forumDbContext.Topics.Include(x => x.Messages);
        }

        public async Task<Topic> GetByIdWithDetailsAsync(int id)
        {
            return await _forumDbContext.Topics.Include(x => x.Messages).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Topic entity)
        {
            _forumDbContext.Entry(entity).State = EntityState.Modified;
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
