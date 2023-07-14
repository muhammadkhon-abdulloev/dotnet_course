using h1.Data;
using h1.Interfaces;
using h1.Models;
using Microsoft.EntityFrameworkCore;

namespace h1.Repository;

public class UserRepository: IUserRepository
{
    private readonly DataContext _db;
    public UserRepository(DataContext db)
    {
        _db = db;
    }

    public ICollection<User> GetUsers()
    {
        return _db.User.ToList();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        var user = await _db.User.FirstOrDefaultAsync(u => u.Id == id);

        return user;
    }

    public async Task<bool> CreateUser(User user)
    {
        await _db.User.AddAsync(user);
        await _db.SaveChangesAsync();
        
        return true;
    }

    public async Task<User?> UpdateUser(User userData)
    {
        var user = await _db.User.FirstOrDefaultAsync(u => u.Id == userData.Id);
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
        var user = await _db.User.FirstOrDefaultAsync(u => u.Id == id);
        if (user == null)
        {
            return null;
        }

        _db.User.Remove(user);
        await _db.SaveChangesAsync();

        return user;
    }
}