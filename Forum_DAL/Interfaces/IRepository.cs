using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Interfaces
{
    public interface IRepository<TEntity> 
    {
        Task<bool> Delete(TEntity entity);
        Task<bool> DeletebyIdAsync(int id);
    }
}
