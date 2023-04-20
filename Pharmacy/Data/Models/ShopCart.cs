using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;

namespace Pharmacy.Data.Models
{
    public class ShopCart
    {
        //змінна для роботи з класом налаштувань БД AppDBContext.cs
        private readonly AppDBContent AppDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.AppDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            //створюємо об'єкт для роботи з сессією
            ISession session =
           services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            //перевіряємо чи був створений кошик чи створюємо новий
            string shopCartId = session.GetString("CartId") ??
           Guid.NewGuid().ToString(); //id кошика
                                      //присваюємо id кошика сессії
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        //функція додавання товару до кошика
        public void AddToCart(Good good, int quantity)
        {
            if (!Contains(good))
            {
                AppDBContent.ShopCartItem.Add(new ShopCartItem
                {
                    ShopCartId = ShopCartId,
                    Good = good,
                    Quantity = quantity,
                    Price = good.Price
                });
            }
            else
            {
                var item = AppDBContent.ShopCartItem.Where(item => item.ShopCartId ==ShopCartId && item.IdGood==good.Id).First();
                item.Quantity = quantity;

            }
            AppDBContent.SaveChanges();

        }
        public List<ShopCartItem> GetShopItems()
        {
            return AppDBContent.ShopCartItem
                .Where(c => c.ShopCartId == ShopCartId)
                .Include(s => s.Good)
                .ToList();
        }

        public int[] GetShopItemsIds()
        {
            return (from item in GetShopItems() select item.Good.Id).ToArray(); 

        }

        public bool Contains(Good good)
        {
            return !GetShopItems().Where(item => item.Good == good).IsNullOrEmpty();
        }

        public void DeleteFromCart(int id)
        {
            AppDBContent.ShopCartItem.Remove(GetItem(id));
            AppDBContent.SaveChanges();
        }

        public ShopCartItem GetItem(int id)
        {
            return GetShopItems().Where(item => item.ShopCartId == ShopCartId && item.IdGood == id).First();

        }

        public void Clear()
        {
            AppDBContent.RemoveRange(GetShopItems());
            AppDBContent.SaveChanges();
        }
    }

}
