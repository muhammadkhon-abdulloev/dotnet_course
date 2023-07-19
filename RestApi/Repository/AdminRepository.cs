using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Interfaces;
using RestApi.Models;

namespace RestApi.Repository;

public class AdminRepository: IAdminRepository
{
    private readonly ApplicationContext _db;
    public AdminRepository(ApplicationContext db)
    {
        _db = db;
    }

    public async Task<Admin?> GetAdminById(int id)
    {
        var admin = await _db.Admins.FirstOrDefaultAsync(a => a.Id == id);
        return admin;
    }

    public async Task<Admin?> GetAdminByUsername(string username)
    {
        var admin = await _db.Admins.FirstOrDefaultAsync(a => a.Username == username);
        return admin;
    }
}