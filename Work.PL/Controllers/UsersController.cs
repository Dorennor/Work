using Microsoft.AspNetCore.Mvc;
using Work.BLL.Interfaces;
using Work.BLL.Models;

namespace Work.PL.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("api/getLoggedUser")]
        public async Task<UserModel?> GetLoggedUserAsync()
        {
            return await _userService.GetLoggedUserAsync();
        }

        [HttpGet]
        [Route("api/getUsers")]
        public async Task<List<UserModel>> GetUsersAsync()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpPost]
        [Route("api/register")]
        public async Task<IActionResult> RegisterAsync([FromBody] UserModel userModel)
        {
            if (userModel == null) return BadRequest();

            var result = await _userService.RegisterAsync(userModel);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserModel userModel)
        {
            if (userModel == null) return BadRequest();

            var result = await _userService.LoginAsync(userModel);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/logout")]
        public async Task LogoutAsync([FromBody] UserModel userModel)
        {
            if (userModel == null) return;

            await _userService.LogoutAsync(userModel);
        }

        [HttpPost]
        [Route("api/addAdministrator")]
        public async Task<IActionResult> AddAdministratorAsync([FromBody] UserModel userModel)
        {
            if (userModel == null) return BadRequest();

            var result = await _userService.RegisterAsync(userModel);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/addManager")]
        public async Task<IActionResult> AddManagerAsync([FromBody] UserModel userModel)
        {
            if (userModel == null) return BadRequest();

            var result = await _userService.RegisterAsync(userModel);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/addUser")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserModel userModel)
        {
            if (userModel == null) return BadRequest();

            var result = await _userService.RegisterAsync(userModel);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/deleteUser")]
        public async Task DeleteUserAsync([FromBody] int id)
        {
            await _userService.DeleteUserAsync(id);
        }
    }
}