using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Interfaces
{
    public interface IRepository<TEntity> 
    {
        Task Delete(TEntity entity);
        Task DeletebyIdAsync(int id);
    }
}
