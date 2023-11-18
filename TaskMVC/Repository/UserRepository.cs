using Microsoft.EntityFrameworkCore;
using TaskMVC.Data;
using TaskMVC.Entity;
using TaskMVC.Interface;

namespace TaskMVC.Repository;
public class UserRepository:IUserRepository
{
    private readonly AppDbContext _appDbcontext;
    public UserRepository(AppDbContext appDbcontext) => _appDbcontext = appDbcontext;

    public async Task<User> GetUserByEmail(string email) => await _appDbcontext.Users.FirstOrDefaultAsync(e => e.Email == email) ?? throw new BadHttpRequestException("User not found");
}
