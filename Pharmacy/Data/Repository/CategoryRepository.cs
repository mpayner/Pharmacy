using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;
using Pharmacy.Data.Utils;

namespace Pharmacy.Data.Repository
{
    public class CategoryRepository : GeneralRepository<Category>, ICategory
    {
        public CategoryRepository(AppDBContent dBContent) : base(dBContent)
        {
        }    

        public Category GetByName(string name)
        {
            return DBContent.Category.Where(category => category.Name == name).FirstOrDefault();
        }

    }
}
