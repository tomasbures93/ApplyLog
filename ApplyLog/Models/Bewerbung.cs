using System.ComponentModel.DataAnnotations;

namespace ApplyLog.Models
{
    public enum Result
    {
        Pending,
        NextRound,
        No,
        Yes
    }
    public class Bewerbung
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please insert Company Name!")]
        [Display(Name = "Position")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2 - 50 Characters")]
        public string position { get; set; }

        [Required(ErrorMessage = "Please insert Location of job!")]
        [Display(Name = "Location of job")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2 - 50 Characters")]
        public string jobort { get; set; }

        [Required(ErrorMessage = "Please insert when have you Applied!")]
        [Display(Name = "Date Applied")]
        public DateTime whenapplied { get; set; }

        [Display(Name = "Expected Salary")]
        public int? gehalt { get; set; }

        [Required(ErrorMessage = "Please insert important Notes!")]
        [Display(Name = "Comment / Notes")]
        [StringLength(1000, ErrorMessage = "Max. 1000 Characters")]
        public string positionComment { get; set; }

        [Required]
        [Display(Name = "Home Office Possible")]
        public bool homeoffice { get; set; }

        [Display(Name = "Application Link / URL")]
        public string? applicationlink { get; set; }

        [Required]
        [Display(Name = "Application Result")]
        public Result result { get; set; }

        public virtual Firma firma { get; set; }
    }
}
