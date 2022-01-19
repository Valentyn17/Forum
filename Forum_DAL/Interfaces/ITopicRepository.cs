using Forum_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Interfaces
{
    public interface ITopicRepository : IRepository<Topic>
    {
        Task<Topic> GetByIdWithDetailsAsync(int id);
        IQueryable<Topic> FindAllWithDetails();

        Task<Topic> AddAsync(Topic entity);
        Task<bool> UpdateAsync(Topic entity);
    }
}
