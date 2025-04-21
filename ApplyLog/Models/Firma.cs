using System.ComponentModel.DataAnnotations;

namespace ApplyLog.Models
{
    public class Firma
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please insert Company Name!")]
        [Display(Name = "Company")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "2 - 100 Characters")]
        public string CompanyName { get; set; }

        [Display(Name = "Company location")]
        public string? Ort { get; set; }

        public virtual Kontakt? Kontakt { get; set; }
    }
}
