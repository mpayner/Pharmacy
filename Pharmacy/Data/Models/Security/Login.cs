using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Data.Models.Security
{
    [NotMapped]
    public class Login
    {
        [Display(Name = "Введіть email")]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Введіть пароль")]

        [Required(ErrorMessage = "Це поле є обов'язковим")]
        [MinLength(6, ErrorMessage ="Довжина пароля повинна бути не менше 6 символів"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
