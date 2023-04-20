using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class DrugRepository : GeneralRepository<Drug>, IDrug
    {
        public DrugRepository(AppDBContent dBContent) : base(dBContent)
        {
        }
    }
}
