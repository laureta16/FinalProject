using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using FinalProjeckt.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Services;

namespace FinalProjeckt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var userDb = await _userService.GetUserAsync();

            return Ok(userDb);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userDb = await _userService.GetUserByIdAsync(id);

            if (userDb == null)
            {
                return NotFound($"User with id = {id} not found");
            }
            else
            {
                return Ok(userDb);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteBooksById(int id)
        {
            await _userService.DeleteUserByIdAsync(id);

            return Ok("Deleted");
        }
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] PostUserDto payload)
        {
            await _userService.PostUserAsync(payload);

            return Ok("New User created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserById(int id, [FromBody] PutUserDto payload)
        {
            await _userService.UpdateUserAsync(id, payload);

            return Ok($"User with id = {id} was updated");
        }
    }
}
