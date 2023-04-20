using System.ComponentModel.DataAnnotations;

namespace Pharmacy.Data.Models
{
    public class MedicalForm
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Drug> Drugs { get; set; }
    }
}