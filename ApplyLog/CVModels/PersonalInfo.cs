using Microsoft.AspNetCore.Identity;

namespace ApplyLog.CVModels
{
    public class PersonalInfo
    {
        public int Id { get; set; }

        public virtual IdentityUser? User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public string TelNummer { get; set; }

        public string? PersonalSummary { get; set; }

        public string? SoftSkills { get; set; }

        public string? TechnicalSkills { get; set; }

        public string? Hobbys { get; set; }
    }
}
