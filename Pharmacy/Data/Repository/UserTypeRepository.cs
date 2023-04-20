using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class UserTypeRepository : GeneralRepository<UserType>, IUserType
    {
        public UserTypeRepository(AppDBContent dBContent) : base(dBContent)
        {
        }
    }
}
