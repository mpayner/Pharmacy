using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Data.Models
{

    public class DrugSubstance
    {
        
        public int DrugId { get; set; }
        public virtual Drug Drug { get; set; }
        public int SubstanceId { get; set; }
        public virtual Substance Substance { get; set; }
        [Range(1, int.MaxValue)]

        public float Quantity { get; set; }
    }
}
