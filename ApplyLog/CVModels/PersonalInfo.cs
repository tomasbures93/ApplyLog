using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApplyLog.CVModels
{
    public class PersonalInfo
    {
        public int Id { get; set; }

        public virtual IdentityUser? User { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Telefon number")]
        public string TelNummer { get; set; }

        [Display(Name = "Personal Summary")]
        public string? PersonalSummary { get; set; }

        [Display(Name = "Soft Skills")]
        public string? SoftSkills { get; set; }

        [Display(Name = "Technical Skills")]
        public string? TechnicalSkills { get; set; }

        [Display(Name = "Hobbys")]
        public string? Hobbys { get; set; }
    }
}
