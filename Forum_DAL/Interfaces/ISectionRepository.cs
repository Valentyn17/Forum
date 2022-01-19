using Forum_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_DAL.Interfaces
{
    public interface ISectionRepository: IRepository<Section>
    {
        Task<Section> GetByIdWithDetailsAsync(int id);
        IQueryable<Section> FindAllWithDetails();

        Task<Section> AddAsync(Section entity);
        Task<bool> UpdateAsync(Section entity);
    }
}
