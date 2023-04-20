using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class MedicalFormRepository : GeneralRepository<MedicalForm>, IMedicalForm
    {
        public MedicalFormRepository(AppDBContent dBContent) : base(dBContent)
        {
        }
    }
}
