using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Data.Models
{
    [PrimaryKey("ShopCartId","IdGood")]
    public class ShopCartItem
    {
        public string ShopCartId { get; set; }

        [ForeignKey("Good")]
        public int IdGood { get; set; }
        public virtual Good Good { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
      
    }
}
