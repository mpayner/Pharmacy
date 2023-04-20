using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory {get;set;}

        public virtual List<Category> ChildCategories { get; set; }

        public virtual List<Good> Goods { get; set; }

        public IEnumerable<Category> ExpandAllCategories()
        {
            var list = new LinkedList<Category>();
            var curCategory = this;
            while (curCategory != null){
                list.AddFirst(curCategory);
                curCategory = curCategory.ParentCategory;
            }

            return list;
        }
    }
}
