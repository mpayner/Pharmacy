using Pharmacy.Data.Models;
using Pharmacy.Data.Models.Security;

namespace Pharmacy.Data.Interfaces
{
    public interface IUser : IGeneral<User>
    {
        public User CheckLogin(Login user);

        public User CheckRegister(Register register);

        public User GetUserByEmail(string email);

        
    }
}
