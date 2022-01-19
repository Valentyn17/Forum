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
    public class SectionRepository : ISectionRepository
    {
        private readonly ForumDbContext _forumDbContext;

        public SectionRepository(ForumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }
        public Task<Section> AddAsync(Section entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Section entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletebyIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Section> FindAllWithDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Section> GetByIdWithDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Section entity)
        {
            throw new NotImplementedException();
        }
    }
}
