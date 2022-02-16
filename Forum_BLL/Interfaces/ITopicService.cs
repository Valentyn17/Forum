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
        /// <summary>
        /// Method that creates topic
        /// </summary>
        /// <param name="model">Topic, we want to create</param>
        /// <returns>Created topic</returns>
        Task<TopicDTO> CreateAsync(TopicDTO model);
        /// <summary>
        /// Get all topics
        /// </summary>
        /// <returns>List of topics</returns>
        IEnumerable<TopicDTO> FindAll();
        /// <summary>
        /// Get topic by id
        /// </summary>
        /// <param name="id">Id of topic</param>
        /// <returns></returns>
        TopicDTO FindById(int id);

        /// <summary>
        /// Get topics by user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>List of selected topics</returns>
        IEnumerable<TopicDTO> GetByUserId(string id);
        /// <summary>
        /// Get topics by section id
        /// </summary>
        /// <param name="id">section id</param>
        /// <returns>List of selected topics</returns>
        IEnumerable<TopicDTO> GetBySectionId(int id);

        /// <summary>
        /// Updates topic
        /// </summary>
        /// <param name="model">Topic to update</param>
        /// <returns>True if success, therefore false</returns>
        Task<bool> UpdateAsync(TopicDTO model);
        /// <summary>
        /// Deletes topic
        /// </summary>
        /// <param name="id">Id of topic to delete</param>
        /// <returns>True if success, therefore false</returns>
        Task<bool> DeleteAsync(int id);
    }
}
