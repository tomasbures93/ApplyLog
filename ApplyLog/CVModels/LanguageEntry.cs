using Microsoft.AspNetCore.Identity;

namespace ApplyLog.CVModels
{
    public enum LanguageLevel
    {
        A1,
        A2,
        B1,
        B2,
        C1,
        C2,
        Native
    }
    public class LanguageEntry
    {
        public int Id { get; set; }

        public virtual IdentityUser? User { get; set; }
        public string LanguageName { get; set; }
        public LanguageLevel Level { get; set; }
    }
}
