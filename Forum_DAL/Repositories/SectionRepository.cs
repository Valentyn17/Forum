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
    public class SectionRepository : ISectionRepository
    {
        private readonly ForumDbContext _forumDbContext;

        public SectionRepository(ForumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }
        public async Task AddAsync(Section entity)
        {
            await _forumDbContext.Sections.AddAsync(entity);
        }

        public async Task Delete(Section entity)
        {
            var element = await _forumDbContext.Sections.Include(x=>x.Topics).FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (element != null)
            {
                _forumDbContext.Sections.Remove(element);
            }
        }

        public async Task DeletebyIdAsync(int id)
        {
            var element = await _forumDbContext.Sections.Include(x => x.Topics).FirstOrDefaultAsync(x => x.Id == id);
            if (element != null)
            {
                _forumDbContext.Sections.Remove(element);
            }
        }

        public IEnumerable<Section> FindAllWithDetails()
        {
            return _forumDbContext.Sections.Include(x => x.Topics);
        }

        public async Task<Section> GetByIdWithDetailsAsync(int id)
        {
            return await _forumDbContext.Sections.Include(x => x.Topics).FirstOrDefaultAsync(x => x.Id==id);
        }

        public async Task UpdateAsync(Section entity)
        {
            _forumDbContext.Entry(entity).State = EntityState.Modified;
            await _forumDbContext.SaveChangesAsync();
        }
    }
}
