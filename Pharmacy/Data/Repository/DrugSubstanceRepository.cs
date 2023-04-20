using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class DrugSubstanceRepository : GeneralRepository<DrugSubstance>, IDrugSubstance
    {
        public DrugSubstanceRepository(AppDBContent dBContent) : base(dBContent)
        {
        }
    }
}
