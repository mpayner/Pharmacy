using Pharmacy.Data.Models;

namespace Pharmacy.Data.Interfaces
{
    public interface IOrder : IGeneral<Order>
    {
        public void Create(Order order);
    }
}
