using RestApi.Models;

namespace RestApi.Interfaces;

public interface IAdminRepository
{
    Task<Admin?> GetAdminById(int id);
    Task<Admin?> GetAdminByUsername(string username);
}