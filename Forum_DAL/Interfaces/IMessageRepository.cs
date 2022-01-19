using Forum_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Interfaces
{
    public interface IMessageRepository:IRepository<Message>
    {
        Task<Message> GetByIdWithDetailsAsync(int id);
        IQueryable<Message> FindAllWithDetails();

        Task<Message> AddAsync(Message entity);
        Task<bool> UpdateAsync(Message entity);
    }
}
