using Microsoft.AspNetCore.Mvc;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;
using Pharmacy.Data.Utils;

namespace Pharmacy.Controllers
{
    public class GoodController : Controller
    {
        private readonly IGood _goodRepository;
        private readonly ICategory _categoryRepository;

        private readonly ShopCart _shopCart;
        private const int ItemsPerPage = 12,
                          PagesBefore = 2,
                          PagesAfter = 4;
        public GoodController(IGood goodRepository, ShopCart shopCart, ICategory categoryRepository)
        {
            _goodRepository = goodRepository;
            _shopCart = shopCart;
            _categoryRepository = categoryRepository;
        }


        [HttpGet("Good/{category}/{page}")]

        public IActionResult ByCategory(string category, int page)
        {      
            List<Good> goods;
            if (category.Equals("all"))
            {
                goods = _goodRepository.GetRange((page - 1) * ItemsPerPage, ItemsPerPage);
                ViewBag.Pagination = new Pagination(page, _goodRepository.Сount(), ItemsPerPage, PagesBefore, PagesAfter);
            }
            else
            {
                var DBCategory = _categoryRepository.GetByName(category);
                if (DBCategory == null)
                {
                    return NotFound();
                }
                goods = _goodRepository.GetByCategoryIncludeChildRange(DBCategory, (page - 1) * ItemsPerPage, ItemsPerPage);
                ViewBag.Pagination = new Pagination(page, _goodRepository.CountByCategoryIncludeChild(DBCategory), ItemsPerPage, PagesBefore, PagesAfter);
            }
            ViewData["GoodList"] = goods;
            ViewData["CartItems"] = _shopCart.GetShopItemsIds();
            return View("All");
        }

        [Route("Good/{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            ViewBag.ShowCartButton = !_shopCart.GetShopItemsIds().Contains(id);
            ViewBag.Good = _goodRepository.Get(id);
            return View();
        }


    }
}
