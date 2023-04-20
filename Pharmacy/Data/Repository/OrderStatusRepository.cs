using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class OrderStatusRepository : GeneralRepository<OrderStatus>, IOrderStatus
    {

        public OrderStatusRepository(AppDBContent dBContent) : base(dBContent)
        {
        }
    }
}
