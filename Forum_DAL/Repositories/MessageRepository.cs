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
    public class MessageRepository : IMessageRepository
    {
        private readonly ForumDbContext _forumDbContext;
        
        public MessageRepository(ForumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }

        public Task<Message> AddAsync(Message entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletebyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Message> FindAllWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
