using Forum_DAL.Context;
using Forum_DAL.Entities;
using Forum_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ForumDbContext _forumDbContext;
        public UserProfileRepository(ForumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }

        public async Task AddAsync(UserProfile profile)
        {
            await _forumDbContext.AddAsync(profile);
        }

        public async Task Delete(UserProfile profile)
        {
            var element = await _forumDbContext.UserProfiles.FirstOrDefaultAsync(x => x.Id == profile.Id);
            if (element != null)
            {
                _forumDbContext.UserProfiles.Remove(element);
            }
        }

        public IEnumerable<UserProfile> GetAll()
        {
            return _forumDbContext.UserProfiles.Include(x=>x.User);
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _forumDbContext.UserProfiles.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(UserProfile profile)
        {
            _forumDbContext.Entry(profile).State = EntityState.Modified;
        }
    }
}
