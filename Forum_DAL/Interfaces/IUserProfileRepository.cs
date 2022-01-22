using Forum_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Interfaces
{
    public interface IUserProfileRepository
    {
        Task AddAsync(UserProfile profile);
        Task<UserProfile> GetByIdAsync(int id);

        IEnumerable<UserProfile> GetAll();
        void Update(UserProfile profile);

        Task Delete(UserProfile profile);

    }
}
