using TaskMVC.Entity;

namespace TaskMVC.Dto_s
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Passwword { get; set; }
        public ERole Role { get; set; }
    }
}
