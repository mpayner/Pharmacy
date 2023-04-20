using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class OrderDetailRepository : GeneralRepository<OrderDetail>, IOrderDetail
    {
        public OrderDetailRepository(AppDBContent dBContent) : base(dBContent)
        {
        }
    }
}
