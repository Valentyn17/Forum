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
        /// <summary>
        /// Add message
        /// </summary>
        /// <param name="model">Message to add</param>
        /// <returns>Created message</returns>
        Task<MessageDTO> CreateAsync(MessageDTO model);

        /// <summary>
        /// Get all messages
        /// </summary>
        /// <returns>List of messages</returns>
        IEnumerable<MessageDTO> FindAll();

        /// <summary>
        /// Get message by topic id
        /// </summary>
        /// <param name="id">Topic id</param>
        /// <returns>List of messages</returns>
        IEnumerable<MessageDTO> FindByTopicId(int id);

        /// <summary>
        /// Get message by id
        /// </summary>
        /// <param name="id">Message id</param>
        /// <returns>Message with given id</returns>
        MessageDTO FindById(int id);  
        /// <summary>
        /// Get messages by user id
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>List of messages</returns>
        IQueryable<MessageDTO> FindByUserId(string userId);


        /// <summary>
        /// Upsates messaage
        /// </summary>
        /// <param name="model">Message to update</param>
        /// <returns>True if successfully updated, therefore false.</returns>
        Task<bool> UpdateAsync(MessageDTO model);

        /// <summary>
        /// Delete message by id
        /// </summary>
        /// <param name="id">Id of message we want to delete</param>
        /// <returns>True if successfully deleted, therefore false.</returns>
        Task<bool> DeleteAsync(int id);

    }
}
