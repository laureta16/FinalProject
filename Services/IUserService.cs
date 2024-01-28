using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;

namespace FinalProject.Services;

public interface IUserService
{
 Task<List<User>> GetUserAsync();
 Task<User> GetUserByIdAsync(int id);
 Task PostUserAsync(PostUserDto user);
 Task<User> UpdateUserAsync(int id, PutUserDto user);
 Task DeleteUserByIdAsync(int id);
    
    
}