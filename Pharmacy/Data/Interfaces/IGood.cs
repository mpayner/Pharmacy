using Pharmacy.Data.Models;

namespace Pharmacy.Data.Interfaces
{
    public interface IGood : IGeneral<Good>
    {
        public List<Good> GetByCategory(Category category);
        public List<Good> GetByCategoryIncludeChild(Category category);

        public List<Good> GetByCategoryIncludeChildRange(Category category, int offset, int limit);

        public int CountByCategory(Category category);
        public int CountByCategoryIncludeChild(Category category);


    }
}
