using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ApplyLog.CVModels
{
    public class WorkEntry
    {
        public int Id { get; set; }

        public virtual IdentityUser? User { get; set; }
        public string Company { get; set; }

        public string JobPosition { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public string? Description { get; set; }
    }
}
