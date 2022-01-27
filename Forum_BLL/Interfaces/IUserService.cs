using Forum_BLL.DTO;
using Forum_DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_BLL.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(Register user);
       
        
        /// <summary>
        /// Method that manages loginning process
        /// </summary>
        /// <param name="login">Model for loginning, which contains email and password </param>
        /// <returns>
        /// User who is trying to log in.
        /// </returns>
        Task<User> Login(Login login);
        /// <summary>
        /// Method that allows to get user by email.
        /// </summary>
        /// <param name="email">Users email address.</param>
        /// <returns>
        /// User by email address.
        /// </returns>
        Task<User> GetUserByEmailAsync(string email);
        /// <summary>
        /// Method that returns list of all existing users.
        /// </summary>
        /// <returns>
        /// List of all existing users.
        /// </returns>
        IEnumerable<UserDTO> GetAllUsers();
        /// <summary>
        /// Method that asiigns user to an array of roles.
        /// </summary>
        /// <param name="assignUserToRoles"></param>
        /// <returns></returns>
        Task AssignUserToRoles(AssignUserToRoles assignUserToRoles);
        /// <summary>
        /// Method that creates a new  role.
        /// </summary>
        /// <param name="roleName">Name of new user role.</param>
        /// <returns></returns>
        Task CreateRole(string roleName);

        /// <summary>
        /// Method that returst list of roles for user.
        /// </summary>
        /// <param name="user">Email of user for whome we want to know role</param>
        /// <returns>
        /// List of chosen user roles.
        /// </returns>
        Task<IEnumerable<string>> GetUserRoles(string email);

        /// <summary>
        /// Method returns list of all existing roles.
        /// </summary>
        /// <returns>
        /// List of all existing roles.
        /// </returns>
        Task<IEnumerable<IdentityRole>> GetRoles();

    }
}
