using Forum_DAL.Context;
using Forum_DAL.Entities;
using Forum_DAL.Interfaces;
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
        public Task<Topic> AddAsync(Topic entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Topic entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletebyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Topic> FindAllWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Topic entity)
        {
            throw new NotImplementedException();
        }
    }
}
