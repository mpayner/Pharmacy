using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Data.Models.Security
{
    [NotMapped]
    public class Register
    {
        [Display(Name = "Введіть ім'я")]
        [MinLength(2, ErrorMessage = "Довжина імені не менше 2 символів"),
            MaxLength(25, ErrorMessage = "Довжина імені не більше 25 символів")]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        public string Name { get; set; }
        [Display(Name = "Введіть прізвище")]
        [MinLength(2, ErrorMessage = "Довжина прізвища не менше 2 символів"),
            MaxLength(25, ErrorMessage = "Довжина прізвища не більше 25 символів")]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        public string Surname { get; set; }

        [Display(Name = "Введіть по батькові")]
        [MinLength(5, ErrorMessage = "Довжина по батькові не менше 5 символів"),
            MaxLength(25, ErrorMessage = "Довжина по батькові не більше 25 символів")]
        public string MiddleName { get; set; }

        [Display(Name = "Введіть пошту")]
        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Це поле є обов'язковим")]

        public string Email { get; set; }
        [Display(Name = "Введіть пароль"), MinLength(6)]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name="Повторіть пароль"),MinLength(6)]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Введіть номер телефону")]
        [DataType(DataType.PhoneNumber)]
        [MinLength(10), MaxLength(13)]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        public string PhoneNumber { get; set; }
    }
}
