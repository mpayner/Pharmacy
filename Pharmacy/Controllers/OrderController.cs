using Microsoft.AspNetCore.Mvc;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly ShopCart _shopCart;
        private readonly IDeliveryCompany _deliveryCompany;
        private readonly IUser _user;

        public OrderController(IOrder order, ShopCart shopCart, IDeliveryCompany deliveryCompany, IUser user)
        {
            _order = order;
            _shopCart = shopCart;
            _deliveryCompany = deliveryCompany;
            _user = user;
        }

        [HttpGet("order/create")]
        public IActionResult CreateOrderForm()
        {
            ViewBag.Companies = _deliveryCompany.GetAll();
            var order = new Order();
            if (User.Identity.IsAuthenticated)
            {
                var authUser = _user.GetUserByEmail(User.Identity.Name);
                order.Name = authUser.Name;
                order.Surname = authUser.Surname;
            
            }
            return View(order);
        }
        
        [HttpPost("order/create/checkout")]
        public IActionResult Checkout(Order order)
        {
            
            _shopCart.ShopItems = _shopCart.GetShopItems();
            if (_shopCart.ShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Ви повинні додати товар!");
            }
            if (ModelState.IsValid)
            {
                _order.Create(order);
                _shopCart.Clear();
                return RedirectToAction("Complete");
            }
            ViewBag.Companies = _deliveryCompany.GetAll();
            //ViewBag.Errors = ModelState.ValidationState;
            return View("CreateOrderForm", order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Замовлення відправлено на обробку!";
            return View();
        }


    }
}
