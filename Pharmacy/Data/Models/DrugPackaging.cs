
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Text;

namespace Pharmacy.Data.Models
{
    public class DrugPackaging : Good
    {
        [ForeignKey("Drug")]
        public int DrugId { get; set; }
        public virtual Drug Drug { get; set; }
        public int PackQuantity { get; set; }

        public string Discriminator => "DrugPackaging";
        public override string Type()
        {
            return Discriminator;
        }
    }
}
