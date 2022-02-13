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
        Message GetById(int id);
        IEnumerable<Message> GetAll();

        Task AddAsync(Message entity);
        void Update(Message entity);
    }
}
