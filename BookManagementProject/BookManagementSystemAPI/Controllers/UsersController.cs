using BookManagementSystemData.Models;
using BookManagementSystemData.Services;
using BookManagementSystemData.ViewModels.UserViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetItems>>> GetUsers()
        {
            var result = await _userService.GetAllUsers();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/login
        [HttpGet("login")]
        public async Task<ActionResult<User>> Login(string id, string pass)
        {
            var result = await _userService.Login(id, pass);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
