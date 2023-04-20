using Pharmacy.Data.Models;

namespace Pharmacy.Data.Interfaces
{
    public interface ICategory : IGeneral<Category>
    {
        public Category GetByName(string name);

    }
}
