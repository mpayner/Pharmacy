
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Data.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Введіть ім'я")]
        [MinLength(2, ErrorMessage = "Довжина імені не менше 2 символів"),
            MaxLength(25, ErrorMessage = "Довжина імені не більше 25 символів")]
		[Required(ErrorMessage = "Це поле є обов'язковим")]
		public string Name { get; set; }
        [Display(Name = "Введіть прізвище")]
		[MinLength(2, ErrorMessage = "Довжина прізвища не менше 5 символів"),
			MaxLength(25, ErrorMessage = "Довжина прізвища не більше 25 символів")]
		[Required(ErrorMessage = "Це поле є обов'язковим")]
		public string Surname { get; set; }
        [Display(Name = "Введіть адресу")]
		[MinLength(15, ErrorMessage = "Довжина адреси доставки не менше 15 символів")]
		[Required(ErrorMessage = "Це поле є обов'язковим")]
		public string Address { get; set; }
        [Display(Name = "Введіть номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(10, ErrorMessage ="Довжина не повинна бути менше 10 символів"),MaxLength(13, ErrorMessage = "Довжина не повинна бути більше 13 символів")]
		[Required(ErrorMessage = "Це поле є обов'язковим")]
		public string Phone { get; set; }
        [Display(Name = "Введіть пошту")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
		[Required(ErrorMessage = "Це поле є обов'язковим")]
		public string Email { get; set; }
        
        [ScaffoldColumn(false)] 
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

		[ValidateNever]

		public virtual List<OrderDetail> OrderDetails { get; set; }

        [Required, ForeignKey("Status")]
		[ScaffoldColumn(false)]
		public int StatusId { get; set; }

		[ValidateNever]
		public virtual OrderStatus Status { get; set; }
		[ValidateNever]
		public string? Waybill { get; set; }
        [ForeignKey("Company")]
        [Display(Name = "Оберіть компанію з доставки")]
        [Required]
        public int DeliveryCompanyId { get; set; }
		[ValidateNever]
		public virtual DeliveryCompany Company { get; set; }

        public float CountOrderPrice()
        {
            float generalPrice = 0.0f;
            foreach(OrderDetail details in this.OrderDetails)
            {
                generalPrice += details.Price * details.Quantity;
            }            
            return generalPrice+=CountOrderDeliveryPrice();
        }

        public float CountOrderWeight()
        {
            float generalWeight = 0.0f;
            foreach(OrderDetail detail in this.OrderDetails)
            {
                generalWeight += detail.Good.Weight;
            }
            return generalWeight;
        }

        public float CountOrderDeliveryPrice()
        {
            float generalWeight = CountOrderWeight();
            switch (Company.Id)
            {
                case 1:
                    if (generalWeight < 2)
                    {
                        return 70;
                    }
                    else if (generalWeight > 2 && generalWeight < 10)
                    {
                        return 100;
                    }
                    else
                    {
                        return 140;
                    }
                case 2:
                    if (generalWeight < 2)
                    {
                        return 40;
                    }
                    else if (generalWeight > 2 && generalWeight < 10)
                    {
                        return 70;
                    }
                    else
                    {
                        return 110;
                    }
                case 3:
                    if (generalWeight < 2)
                    {
                        return 45;
                    }
                    else if (generalWeight > 2 && generalWeight < 10)
                    {
                        return 80;
                    }
                    else
                    {
                        return 120;
                    }
                default:
                    return 0.0f;
            }
        }

    }
}
