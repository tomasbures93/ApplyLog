using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApplyLog.CVModels
{
    public class EducationEntry
    {
        public int Id { get; set; }

        public virtual IdentityUser? User { get; set; }
        public string Institut { get; set; }

        public string Subject { get; set; }

        public string Degree { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string? Description { get; set; }
    }
}
