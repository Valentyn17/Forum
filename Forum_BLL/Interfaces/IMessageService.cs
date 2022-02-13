using Forum_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_BLL.Interfaces
{
    public interface IMessageService
    {
        Task<MessageDTO> CreateAsync(MessageDTO model);

        IEnumerable<MessageDTO> FindAll();

        IEnumerable<MessageDTO> FindByTopicId(int id);
        MessageDTO FindById(int id);  
        IQueryable<MessageDTO> FindByUserId(string userId);

        Task<bool> UpdateAsync(MessageDTO model);

        
        Task<bool> DeleteAsync(int id);

    }
}
