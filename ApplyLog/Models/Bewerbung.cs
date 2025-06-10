using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApplyLog.Models
{
    public enum Result
    {
        Pending,
        Next_Round,
        Rejected,
        Accepted
    }

    public enum JobType
    {
        Full_Time,
        Part_Time,
        Internship,
        Contract
    }
    public class Bewerbung
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please insert Company Name!")]
        [Display(Name = "Position")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2 - 50 Characters")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Please insert Location of job!")]
        [Display(Name = "Location of job")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2 - 50 Characters")]
        public string JobOrt { get; set; }

        [Required(ErrorMessage = "Please insert when have you Applied!")]
        [Display(Name = "Date Applied")]
        [DataType(DataType.Date)]
        public DateTime WhenApplied { get; set; }

        [Display(Name = "Expected Salary")]
        public int? Gehalt { get; set; }

        [Required(ErrorMessage = "Please insert important Notes!")]
        [Display(Name = "Comment / Notes")]
        [StringLength(1000, ErrorMessage = "Max. 1000 Characters")]
        public string PositionComment { get; set; }

        [Required]
        [Display(Name = "Home Office Possible")]
        public bool HomeOffice { get; set; }

        [Display(Name = "Application Link / URL")]
        public string? ApplicationLink { get; set; }

        [Required]
        [Display(Name = "Application Result")]
        public Result Result { get; set; }

        [Required]
        [Display(Name = "Type of Job")]
        public JobType JobType { get; set; }

        [DataType(DataType.Date)]
        public DateTime? InterviewDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastUpdateAt { get; set; }

        public virtual Firma Firma { get; set; }

        public virtual IdentityUser? User { get; set; }

        public Bewerbung()
        {
            LastUpdateAt = DateTime.Now;
        }
    }
}
