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
        Topic GetById(int id);
        IEnumerable<Topic> GetAll();

        Task AddAsync(Topic entity);
        void Update(Topic entity);
    }
}
