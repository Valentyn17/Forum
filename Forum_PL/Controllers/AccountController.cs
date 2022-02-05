using Forum_BLL.DTO;
using Forum_BLL.Interfaces;
using Forum_PL.Filters;
using Forum_PL.Helpers;
using Forum_PL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forum_PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ModelStateActionFilter]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;

        public AccountController(
            IUserService userService,
            IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            await _userService.Register(new Register
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                DateOfBirth=model.DateOfBirth
            });

            return Created(string.Empty, string.Empty);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userService.Login(new Login
            {
                Email = model.Email,
                Password = model.Password
            });


            if (user is null) return BadRequest();

            HttpContext.Session.SetInt32("id", 228);

            Console.WriteLine(HttpContext.Session.GetInt32("id"));

            var roles = await _userService.GetUserRoles(user.Email);

            return Ok(JwtHelper.GenerateJwt(user, roles, _jwtSettings));
        }

        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(CreateRoleModel model)
        {
            await _userService.CreateRole(model.RoleName);
            return Ok();
        }

        [HttpGet("getRoles")]
        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _userService.GetRoles());
        }

        [HttpPost("assignUserToRole")]
        public async Task<IActionResult> AssignUserToRole(AssignUserToRoleModel model)
        {
            await _userService.AssignUserToRoles(new AssignUserToRoles
            {
                Email = model.Email,
                Roles = model.Roles
            });

            return Ok();
        }

    }
}
