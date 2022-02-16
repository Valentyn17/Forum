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
        /// <summary>
        /// Create section
        /// </summary>
        /// <param name="model">Section to create</param>
        /// <returns>Created section</returns>
        Task<SectionDTO> CreateAsync(SectionDTO model);

        /// <summary>
        /// Get all sections
        /// </summary>
        /// <returns>List of sections</returns>
        IEnumerable<SectionDTO> FindAll();

        /// <summary>
        /// Get section by id
        /// </summary>
        /// <param name="id">Id of message we want to find</param>
        /// <returns>Message with given id</returns>
        SectionDTO FindById(int id);

        /// <summary>
        /// Update section
        /// </summary>
        /// <param name="model">Section to update</param>
        /// <returns>True if success, therefore false</returns>
        Task<bool> UpdateAsync(SectionDTO model);

        /// <summary>
        /// Delete section
        /// </summary>
        /// <param name="id">Id of section which we want to delete</param>
        /// <returns>True if success, therefore false</returns>
        Task<bool> DeleteAsync(int id);
    }
}
