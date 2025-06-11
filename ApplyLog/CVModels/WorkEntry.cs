using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApplyLog.CVModels
{
    public class WorkEntry
    {
        public int Id { get; set; }

        public virtual IdentityUser? User { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Titel")]
        public string JobPosition { get; set; }

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
