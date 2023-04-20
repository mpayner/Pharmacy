

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data.Models.Security;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true), Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Display(Name = "Введіть ім'я")]
        [MinLength(2, ErrorMessage = "Довжина імені не менше 2 символів"),
            MaxLength(25, ErrorMessage = "Довжина імені не більше 25 символів")]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        public string Name { get; set; }
        
        [MinLength(2, ErrorMessage = "Довжина прізвища не менше 5 символів"),
            MaxLength(25, ErrorMessage = "Довжина прізвища не більше 25 символів")]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        public string Surname { get; set; }

        [MinLength(2, ErrorMessage = "Довжина прізвища не менше 5 символів"),
            MaxLength(25, ErrorMessage = "Довжина прізвища не більше 25 символів")]
        public string MiddleName { get; set; }

        [StringLength(25)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Це поле є обов'язковим")]

        public string Email { get; set; }
        [MinLength(6)]
        public string Password { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MinLength(10), MaxLength(13)]
        [Required(ErrorMessage = "Це поле є обов'язковим")]
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Type")]
        public int UserTypeId { get; set; }
        public virtual UserType Type { get; set; }

        public User() { }


        public User(Register data)
        {
            Name = data.Name;
            Surname = data.Surname;
            MiddleName = data.MiddleName;
            Email = data.Email;
            Password = data.Password;
            PhoneNumber = data.PhoneNumber;
        }
    }


}
