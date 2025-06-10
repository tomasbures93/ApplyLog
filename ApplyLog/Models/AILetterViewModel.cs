using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace ApplyLog.Models
{
    public class AILetterViewModel
    {
        [Required]
        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Address")]
        public string? CompanyAddress { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string? Email {  get; set; }

        [Required]
        [Display(Name = "For which position are you applying?")]
        public string PositionName { get; set; }

        [Required]
        [Display(Name = "Why are you interested in working at this company?")]
        public string WhyIwant { get; set; }

        [Required]
        [Display(Name = "Could you describe your technical skill set?")]
        public string TechSkills { get; set; }

        [Required]
        [Display(Name = "Could you describe your soft skills?")]
        public string SoftSkills { get; set; }

        [Display(Name = "Is there anything else you would like to add?")]
        public string? MoreInfo { get; set; }
    }
}
