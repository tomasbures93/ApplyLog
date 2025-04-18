using System.ComponentModel.DataAnnotations;
using ApplyLog.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ApplyLog.Models
{
    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }
    public class TODO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "2 - 50 Characters")]
        [Display(Name = "Title")]
        public string Titel { get; set; }

        [Required]
        [StringLength(400, ErrorMessage = "Maximum 400 Characters")]
        [Display(Name = "Description")]
        public string Describtion { get; set; }
        public DateTime CreationTime { get; set; }

        [Required]
        [Display(Name = "Deadline")]
        [FutureTime]
        public DateTime Deadline {  get; set; }

        [Required]
        [Display(Name = "Priority")]
        public PriorityLevel PriorityLevel { get; set; }
    }
}
