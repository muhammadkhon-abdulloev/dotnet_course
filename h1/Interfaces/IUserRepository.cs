using h1.Models;

namespace h1.Interfaces;

public interface IUserRepository
{
    ICollection<User> GetUsers();
    Task<User?> GetUserById(Guid id);
    Task<bool> CreateUser(User user);
    Task<User?> UpdateUser(User user);
    Task<User?> DeleteUser(Guid id);
}