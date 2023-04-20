using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class DeliveryCompanyRepository : GeneralRepository<DeliveryCompany>, IDeliveryCompany
    {
        public DeliveryCompanyRepository(AppDBContent dBContent) : base(dBContent)
        {
        }
    }
}
