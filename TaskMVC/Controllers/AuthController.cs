using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskMVC.Dto_s;
using TaskMVC.Entity;
using TaskMVC.Service;

namespace TaskMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;

        public AuthController(AuthService authService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _authService = authService;
            _singInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            var response = new LoginDto();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (passwordCheck)
                {
                    var result = await _singInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
                    if (result.Succeeded)
                    {
                        var rol = await _userManager.GetRolesAsync(user);
                        foreach (var rolle in rol)
                        {
                            if (rolle == "ADMIN")
                            {
                                return RedirectToAction("Index2", "Product");
                            }
                            if (rolle == "USER")
                            {
                                return RedirectToAction("Index", "Product");

                            }
                        }

                    }
                }
                TempData["Error"] = "Parol noto'g'ri";
                return View(loginDto);
            }

            TempData["Error"] = "Foydalanuvchi topilmadi";
            return RedirectToAction("Login", "Auth");
        }

        public async Task<IActionResult> Register()
        {
            var response = new RegisterDto();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return View(registerDto);

            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "Elektron pochta allaqachon ishlatilgan.");
                return View(registerDto);
            }

            var newUser = new User()
            {
                Email = registerDto.Email,
                UserName = registerDto.Email
            };

            var result = await _userManager.CreateAsync(newUser, registerDto.Passwword);

            if (result.Succeeded)
            {
                if (registerDto.Role == 0)
                {
                    await _userManager.AddToRoleAsync(newUser, ERole.ADMIN.ToString());
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    await _userManager.AddToRoleAsync(newUser, ERole.USER.ToString());
                    return RedirectToAction("Login", "Auth");
                }
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(registerDto);
            }
        }
    }
}
