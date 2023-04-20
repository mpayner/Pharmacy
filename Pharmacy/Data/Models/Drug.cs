
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmacy.Data.Models
{
    public class Drug
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}
        [Column(TypeName ="Text")]
        public string Name{get;set;}
        [Column(TypeName = "Text")]
        public string Instruction{get;set;}
        public virtual List<DrugSubstance> DrugSubstance { get;set;}
        public virtual List<DrugPackaging> DrugPackaging { get; set; }


        [ForeignKey ("Form")]
        public int FormId{get;set;}
        public virtual MedicalForm Form{get;set;}
        public float Dose {get;set;}
        [Column(TypeName = "Text")]
        public string Aindication{get;set;}
        [Column(TypeName = "Text")]

        public string Contraindication{get;set;}
        [Column(TypeName = "Text")]

        public string SideEffects{get;set;}

       
    }


}
