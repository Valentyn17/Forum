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
        IEnumerable<Topic> FindAllWithDetails();

        Task AddAsync(Topic entity);
        Task UpdateAsync(Topic entity);
    }
}
