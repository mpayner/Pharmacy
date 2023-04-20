using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Data.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int GoodId { get; set; }
        public virtual Good Good { get; set; }
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public float Price { get; set; } 

    }
}
