namespace Pharmacy.Data.Models
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Order> Orders { get; set; } 
    }
}