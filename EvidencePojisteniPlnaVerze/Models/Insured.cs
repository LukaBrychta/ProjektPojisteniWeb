using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace EvidencePojisteniPlnaVerze.Models
{
    public class Insured
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Jméno")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Příjmení")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Telefon")]
        public int PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Ulice")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Číslo popisné")]
        public int HouseNumber { get; set; }
        [Required]
        [Display(Name = "Město")]
        public string City { get; set; }
        [Required]
        [Display(Name = "PSČ")]
        public int Zip { get; set; }
        public List<Insurance> Insurances { get; set; } = new List<Insurance>();

    }
}
