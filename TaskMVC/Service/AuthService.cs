using TaskMVC.Data;
using TaskMVC.Dto_s;
using TaskMVC.Entity;
using TaskMVC.Interface;
using Mapster;

namespace TaskMVC.Service
{
    public class AuthService
    {
        private readonly AppDbContext _appDbcontext;
        private readonly IUserRepository _userRepository;
        public AuthService(AppDbContext appDbcontext, IUserRepository userRepository)
        {
            _appDbcontext = appDbcontext;
            _userRepository = userRepository;
        }
        public bool Login(LoginDto loginDto)
        {
            if (loginDto.Email != null)
            {
                var user = _userRepository.GetUserByEmail(loginDto.Email);
                if (user.Result.PasswordHash == loginDto.Password)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public async Task Register(RegisterDto registerDto)
        {
            var user = registerDto.Adapt<User>();

            user.Email = registerDto.Email;
            user.PasswordHash = registerDto.Passwword;
            _appDbcontext.Users.Add(user);
            await _appDbcontext.SaveChangesAsync();
        }
    }
}
