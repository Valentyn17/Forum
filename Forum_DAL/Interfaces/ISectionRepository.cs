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
        IEnumerable<Section> FindAllWithDetails();

        Task AddAsync(Section entity);
        Task UpdateAsync(Section entity);
    }
}
