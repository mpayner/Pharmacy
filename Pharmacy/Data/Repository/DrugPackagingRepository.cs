using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class DrugPackagingRepository : GeneralRepository<DrugPackaging>, IDrugPackaging
    {
        public DrugPackagingRepository(AppDBContent dBContent) : base(dBContent)
        {
        }
    }
}
