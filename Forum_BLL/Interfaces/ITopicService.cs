using Forum_BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_BLL.Interfaces
{
    public interface ITopicService
    {
        Task<TopicDTO> CreateAsync(TopicDTO model);

        IEnumerable<TopicDTO> FindAll();

        TopicDTO FindById(int id);
        IEnumerable<TopicDTO> GetByUserId(string id);
        IEnumerable<TopicDTO> GetBySectionId(int id);

        Task<bool> UpdateAsync(TopicDTO model);
        Task<bool> DeleteAsync(int id);
    }
}
