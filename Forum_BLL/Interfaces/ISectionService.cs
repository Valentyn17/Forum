using Forum_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_BLL.Interfaces
{
    public interface ISectionService
    {
        Task<SectionDTO> CreateAsync(SectionDTO model);

        IEnumerable<SectionDTO> FindAll();

        SectionDTO FindById(int id);

        Task<bool> UpdateAsync(SectionDTO model);


        Task<bool> DeleteAsync(int id);
    }
}
