﻿using System.ComponentModel.DataAnnotations;

namespace ApplyLog.Models
{
    public class Kontakt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please insert Phone Number ( If not available, insert ( - ) )!")]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Please insert EMail address!")]
        [Display(Name = "EMail")]
        [EmailAddress(ErrorMessage = "Please enter a valid email adress")]
        public string Email { get; set; }

        [Display(Name = "Website")]
        [RegularExpression("^[w]{3}\\.(.{1,20})\\.[\\w]{1,7}$", ErrorMessage = "URL format: www.website.de")]
        public string? Website { get; set; }
    }
}
