using FinalProjeckt.Data;
using FinalProjeckt.Data.DTOs;
using FinalProjeckt.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Services;

public class UserService:IUserService
{
    
    private AppDbContext _dbContext;
        
    public UserService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetUserAsync()
    {
        var userDb = await _dbContext.Users.ToListAsync();
        return userDb;

    }

    public async Task<User> GetUserByIdAsync(int id)
    {
        var userFromDb = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        return userFromDb;
    }

    public async Task PostUserAsync(PostUserDto user)
    {
        var newUser = new User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Role = user.Role,
                
        };

        await _dbContext.Users.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();    }

    public async Task<User> UpdateUserAsync(int id, PutUserDto user)
    {
        var usersFromDb = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        if(usersFromDb != null)
        {
            usersFromDb.FirstName = user.FirstName;
            usersFromDb.LastName = user.LastName;
            usersFromDb.Email = user.Email;
            usersFromDb.Role = user.Role;

            await _dbContext.SaveChangesAsync();
        }

        return usersFromDb;    }

    public async Task DeleteUserByIdAsync(int id)
    {
        var usersFromDb = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (usersFromDb != null)
        {
            _dbContext.Users.Remove(usersFromDb);
            await _dbContext.SaveChangesAsync();
        }
    }
}