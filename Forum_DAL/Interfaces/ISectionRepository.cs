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
        Section GetByIdAsync(int id);
        IEnumerable<Section> GetAll();

        Task AddAsync(Section entity);
        void Update(Section entity);
    }
}
