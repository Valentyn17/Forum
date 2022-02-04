using AutoMapper;
using Forum_BLL.DTO;
using Forum_BLL.Interfaces;
using Forum_BLL.Validation;
using Forum_DAL.Entities;
using Forum_DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum_BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
      

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
             _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task AssignUserToRoles(AssignUserToRoles assignUserToRoles)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == assignUserToRoles.Email);
            var roles = _roleManager.Roles.ToList().Where(r => assignUserToRoles.Roles.Contains(r.Name, StringComparer.OrdinalIgnoreCase))
                .Select(r => r.NormalizedName).ToList();

            var result = await _userManager.AddToRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(';', result.Errors.Select(x => x.Description)));
            }

        }

        public async Task CreateRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new ForumException($"Role could not be created: {roleName}.");

            }
        }

            public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _userManager.Users.ToList();
            var result = _mapper.Map<IEnumerable<UserDTO>>(users);
            return result;
        }

        public async Task<IEnumerable<string>> GetUserRoles(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new ForumException("User with such email doesn't exist");
            }
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<User> Login(Login login)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == login.Email);
            if (user is null)
                return null;

            return await _userManager.CheckPasswordAsync(user, login.Password) ? user : null;


        }

        public async Task<bool> Register(Register user)
        {
            var newUser = new User
            {
                Email = user.Email,
                UserName=user.Email
            };

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (!result.Succeeded)
            {
                return false;
            }
            await _userManager.AddToRoleAsync(newUser, "user");

            

            var userId = this.GetUserByEmailAsync(user.Email).Result.Id;
            var userProfile = new UserProfile
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserId = userId,
                DateOfBirth = user.DateOfBirth
            };
            await _unitOfWork.UserProfileRepository.AddAsync(userProfile);
            newUser.UserProfile = userProfile;
            await _userManager.UpdateAsync(newUser);
            return true;

        }
    }
}
