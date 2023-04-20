using Microsoft.EntityFrameworkCore;
using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class SubstanceRepository : GeneralRepository<Substance>, ISubstance
    {
        public SubstanceRepository(AppDBContent dBContent) : base(dBContent)
        {
        }
    }
}
