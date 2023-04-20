using Microsoft.AspNetCore.Mvc;
using Pharmacy.Data.Interfaces;

namespace Pharmacy.Controllers
{
    public class HomeController : Controller
    {
        public readonly ICategory _categoryRepository;

        public HomeController(ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.Categories = _categoryRepository.GetAll();
            return View();
        }
    }
}
