using Microsoft.AspNetCore.Mvc;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;
using Pharmacy.Data.Models.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Pharmacy.Controllers
{
    public class SecurityController : Controller
    {
        public readonly IUser _userRepository;

        public SecurityController(IUser user)
        {
            _userRepository = user;
        }

        [Route("/login")]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost("/login/checkout")]
        [ValidateAntiForgeryToken]
        public IActionResult LoginCheckout(Login loginData)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.GetUserByEmail(loginData.Email)==null)
                {
                    ModelState.AddModelError("", "Користувача не існує, зареєструйтеся будь-ласка");
                }else
                {
                    var registeredUser = _userRepository.CheckLogin(loginData);
                    if (registeredUser!=null)
                    {

                        Authenticate(registeredUser); 
                        return Redirect("/profile");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Пароль невірний");

                    }
                }
            }
            return View("login", loginData);

        }

        [Route("/register")]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost("/register/checkout")]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterCheckout(Register registerData)
        {
            if (ModelState.IsValid)
            {
                
                if (_userRepository.CheckRegister(registerData)!=null)
                {
                    ModelState.AddModelError("", "Користувач вже існує");
                }else if (!registerData.Password.Equals(registerData.ConfirmPassword))
                {
                    ModelState.AddModelError("", "Уведені паролі не співпадають");
                }
                else
                {
                    var user = new User(registerData);
                    _userRepository.Add(user);
                    Authenticate(user);
                    return Redirect("/");                    
                }
            }
            return View("register", registerData);
        }



        private void Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Type.Name),
                new Claim("FirsName", user.Name),
                new Claim("LastName", user.Surname)

            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "AuthentificationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [Route("/logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

    }
}
