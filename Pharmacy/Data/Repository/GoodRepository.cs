using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Pharmacy.Data.Database;
using Pharmacy.Data.Interfaces;
using Pharmacy.Data.Models;

namespace Pharmacy.Data.Repository
{
    public class GoodRepository : GeneralRepository<Good>, IGood
    {
        public GoodRepository(AppDBContent dBContent) : base(dBContent)
        {
        }

        public int CountByCategory(Category category)
        {
            return DBContent.Good.Where(good => good.Category == category).Count();
        }

        public int CountByCategoryIncludeChild(Category category)
        {
            var categoryWithChilds = DBContent.Category.Include(c => c.ChildCategories).FirstOrDefault(c => c.Id == category.Id);
            if (categoryWithChilds == null)
            {
                return category.Goods.Count;
            }

            int amount = categoryWithChilds.Goods.Count;

            foreach (var childCategory in categoryWithChilds.ChildCategories)
            {
                amount+= CountByCategory(childCategory);
            }
            return amount;
        }

        public List<Good> GetByCategory(Category category)
        {
            return DBContent.Good.Where(good => good.Category == category).ToList();
        }

        public List<Good> GetByCategoryIncludeChild(Category category)
        {
            var categoryWithChilds = DBContent.Category.Include(c => c.ChildCategories).FirstOrDefault(c => c.Id == category.Id);
            if (categoryWithChilds == null)
            {
                return new List<Good>();
            }

            var goods = categoryWithChilds.Goods.ToList();

            foreach (var childCategory in categoryWithChilds.ChildCategories)
            {
                goods.AddRange(GetByCategory(childCategory));
            }
            return goods;
        }

        public List<Good> GetByCategoryIncludeChildRange(Category category, int offset, int limit)
        {
            return GetByCategoryIncludeChild(category).Skip(offset).Take(limit).ToList();

        }

        
    }
}
