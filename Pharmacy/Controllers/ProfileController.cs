using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy.Data.Interfaces;

namespace Pharmacy.Controllers
{
    [Authorize(Roles = "Client, Admin")]
    public class ProfileController : Controller
    {
        public readonly IUser _userRepository;

        public ProfileController(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("/profile")]
        public IActionResult General()
        {
            ViewBag.User = _userRepository.GetUserByEmail(User.Identity.Name);
            return View();
        }
    }
}
