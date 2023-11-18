using TaskMVC.Entity;

namespace TaskMVC.Interface
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
    }
}
