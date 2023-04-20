using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace Pharmacy.Data.Models
{
    public abstract class Good
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "Text")]
        public string Name { get; set; }
        [Column(TypeName ="Text")]
        public string Description { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public int StorageQuantity { get; set; }
        public string PhotoPath { get; set; }

        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public virtual List<OrderDetail> OrderGoods { get; set; }
        
        public abstract string Type();
    
    }
}
