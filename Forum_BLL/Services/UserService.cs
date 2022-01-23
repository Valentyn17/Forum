using AutoMapper;
using Forum_BLL.DTO;
using Forum_BLL.Interfaces;
using Forum_DAL.Entities;
using Forum_DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum_BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
             _mapper = mapper;
        }


        public Task AssignUserToRoles(AssignUserToRoles assignUserToRoles)
        {
            throw new NotImplementedException();
        }

        public Task CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetRoles(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentityRole>> GetRoles()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> Login(Login login)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(RegisterModel user)
        {
            throw new NotImplementedException();
        }
    }
}
