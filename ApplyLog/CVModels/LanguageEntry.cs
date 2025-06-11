using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Language")]
        public string LanguageName { get; set; }

        [Display(Name = "Niveau")]
        public LanguageLevel Level { get; set; }
    }
}
