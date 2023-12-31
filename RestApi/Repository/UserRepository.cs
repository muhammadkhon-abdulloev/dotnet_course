using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Interfaces;
using RestApi.Models;

namespace RestApi.Repository;

public class UserRepository: IUserRepository
{
    private readonly ApplicationContext _db;
    public UserRepository(ApplicationContext db)
    {
        _db = db;
    }

    public ICollection<User> GetUsers()
    {
        return _db.Users.ToList();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);

        return user;
    }

    public async Task<bool> CreateUser(User user)
    {
        await _db.Users.AddAsync(user);
        await _db.SaveChangesAsync();
        
        return true;
    }

    public async Task<User?> UpdateUser(User userData)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == userData.Id);
        if (user == null)
        {
            return null;
        }

        user.Age = userData.Age;
        user.Name = userData.Name;
        await _db.SaveChangesAsync();

        return userData;
    }

    public async Task<User?> DeleteUser(Guid id)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            return null;
        }

        _db.Users.Remove(user);
        await _db.SaveChangesAsync();

        return user;
    }
}