using Microsoft.AspNetCore.Identity;

namespace ApplyLog.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        public string Refnr { get; set; }

        public string Beruf { get; set; }

        public string Firma { get; set; }

        public string? Titel { get; set; }

        public DateOnly? Saved { get; set; }

        public virtual IdentityUser? User { get; set; }

        public Favorite()
        {
            Saved = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
