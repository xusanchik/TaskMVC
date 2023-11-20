using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
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
        private readonly IToastNotification _notification;

        public AuthController(AuthService authService, UserManager<User> userManager, SignInManager<User> signInManager, IToastNotification notification)
        {
            _authService = authService;
            _singInManager = signInManager;
            _userManager = userManager;
            _notification = notification;
        }

        public IActionResult Login()
        {
            //var response = new LoginDto();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                _notification.AddErrorToastMessage("Not Found ");
                return View(loginDto);
            }
            if(loginDto.Email == null || loginDto.Password == null)
            {

                return RedirectToAction("Login", "Auth");

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
                            if (rolle == "ADMIN" || rolle == "USER")
                            {
                                _notification.AddSuccessToastMessage("ADMIN");
                                return RedirectToAction("Index2", "Product");

                            }
                        
                        }

                    }
                }
                else
                {
                    return RedirectToAction("Login", "Auth");

                }
            }
            return RedirectToAction("Login", "Auth");
        }
        [ValidateAntiForgeryToken]
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
                    return  RedirectToAction("Login", "Auth");
                }
                else
                {
                    await _userManager.AddToRoleAsync(newUser, ERole.USER.ToString());
                    _notification.AddSuccessToastMessage("Registration successfully!");

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
