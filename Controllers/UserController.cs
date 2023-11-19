using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using FinalProjeckt.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjeckt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var UserDb = FakeDB.UserDb.ToList();

            return Ok(UserDb);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var UsersDb = FakeDB.UserDb.FirstOrDefault(x => x.Id == id);

            if (UsersDb == null)
            {
                return NotFound($"Task with id = {id} not found");
            }
            else
            {
                return Ok(UsersDb);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteUserById(int id)
        {
            var UsersDb = FakeDB.UserDb.FirstOrDefault(x => x.Id == id);
            if (UsersDb == null)
            {
                return NotFound($"users with id = {id} not found");
            }
            else
            {
                FakeDB.UserDb.Remove(UsersDb);
                return Ok($"user with id = {id} was removed");
            }
        }
        [HttpPost]
        public IActionResult PostUser([FromBody] PostUserDto payload)
        {
            var newUser = new User()
            {
                Id = new Random().Next(10, 100),
                FirstName= payload.FirstName,
                LastName = payload.LastName,
                Email = payload.Email,
                Role = payload.Role
            };

            FakeDB.UserDb.Add(newUser);

            return Ok("New user");
        }



        [HttpPut("{id}")]
        public IActionResult UpdateTasksById(int id, [FromBody] PutUserDto payload)
        {
            var UsersDb = FakeDB.UserDb.FirstOrDefault(x => x.Id == id);

            if (UsersDb == null)
            {
                return NotFound($"User with id = {id} not found");
            }
            else
            {
                UsersDb.FirstName = payload.FirstName;
                UsersDb.LastName = payload.LastName;
                UsersDb.Email = payload.Email;
                UsersDb.Role= payload.Role;


                return Ok($"User with id = {id} was updated");
            }
        }

    }
}

