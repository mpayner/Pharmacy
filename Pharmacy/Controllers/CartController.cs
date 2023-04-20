using Microsoft.AspNetCore.Mvc;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;
using System.Web.WebPages;

namespace Pharmacy.Controllers
{
    public class CartController : Controller
    {
        private readonly IGood _goodRep;
        private readonly ShopCart _shopCart;

        public CartController(IGood goodRep, ShopCart shopCart)
        {
            _goodRep = goodRep;
            _shopCart = shopCart;
        }
        [Route("/cart")]
        public IActionResult Cart()
        {
            ViewData["Cart"] = _shopCart.GetShopItems();
            return View();
        }

        [HttpGet("{id:int}/{quantity:int}")]
        [Route("/AddToCart")]
        public IActionResult AddToCart(int id, int quantity)
        {
            var item = _goodRep.Get(id);
            if (item != null )
            {
                _shopCart.AddToCart(item, quantity);
            }
            string referer= Request.Headers["Referer"].ToString();
            string prevUrl = referer.IsEmpty() ? "/cart" : referer;
            return Redirect(prevUrl);
        }

        [Route("/getCartItemIds")]
        public IActionResult GetCartItemsIds()
        {
            
            return Json(_shopCart.GetShopItemsIds());
        }
        [Route("/deleteFromCart/{id}")]
        public IActionResult DeleteFromCart(int id)
        {
            _shopCart.DeleteFromCart(id);
            return Redirect("/cart");
        }
    }
}
