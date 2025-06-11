using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApplyLog.CVModels
{
    public class EducationEntry
    {
        public int Id { get; set; }

        public virtual IdentityUser? User { get; set; }

        [Display(Name = "Institut")]
        public string Institut { get; set; }

        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [Display(Name = "Degree")]
        public string Degree { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
