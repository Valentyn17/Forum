using Forum_DAL.Context;
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
    public class MessageRepository : IMessageRepository
    {
        private readonly ForumDbContext _forumDbContext;
        
        public MessageRepository(ForumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }

        public async Task AddAsync(Message entity)
        {
            await _forumDbContext.AddAsync(entity);
        }

        public async Task Delete(Message entity)
        {
            var element = await _forumDbContext.Messages.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (element != null)
            {
               _forumDbContext.Messages.Remove(element);
            }
        }

        public async Task DeletebyIdAsync(int id)
        {
            var element = await _forumDbContext.Messages.FirstOrDefaultAsync(x => x.Id == id);
            if (element != null)
            {
                _forumDbContext.Messages.Remove(element);
            }
        }

        public IEnumerable<Message> FindAllWithDetails()
        {
            return _forumDbContext.Messages;
        }

        public Task<Message> GetByIdWithDetailsAsync(int id)
        {
            return _forumDbContext.Messages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Message entity)
        {
            _forumDbContext.Entry(entity).State = EntityState.Modified;
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
