using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace EvidencePojisteniPlnaVerze.Models
{
    public class Insurance
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Pojištění")]
        public string TypeInsurance { get; set; }

        [Required]
        [Display(Name = "Částka")]
        public int Amount { get; set; }
        [Required]
        [Display(Name = "Předmět pojištění")]
        public string SubjectInsurance {get; set; }
        [Required]
        [Display(Name = "Platnost od"), DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }
        [Required]
        [Display(Name = "Plastnost do"), DataType(DataType.Date)]

        public DateTime ValidUntil { get; set; }
        [Required]
        [Display(Name = "Pojištěná osoba")]
        public int? InsuredId { get; set; }  
        [Required]
        public Insured? insured { get; set; }
    }
}
