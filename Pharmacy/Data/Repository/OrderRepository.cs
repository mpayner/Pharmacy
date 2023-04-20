using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class OrderRepository : GeneralRepository<Order>, IOrder
    {
        private readonly ShopCart _shopCart;

        public OrderRepository(AppDBContent appDBContent, ShopCart shopCart):
            base(appDBContent)
        {
            this._shopCart = shopCart;
        }

        public void Create(Order order)
        {
            order.CreatedAt = DateTime.Now;
            order.UpdatedAt = DateTime.Now;
            order.StatusId = 1;
            DBContent.Order.Add(order);
            DBContent.SaveChanges();
            var items = _shopCart.ShopItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    GoodId = el.IdGood,
                    OrderId = order.Id,
                    Price = el.Price,
                    Quantity = el.Quantity
                };
                DBContent.OrderDetail.Add(orderDetail);
            }
        DBContent.SaveChanges();
        }
    }

}
