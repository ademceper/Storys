using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Story.Data
{
    public class AppUser:IdentityUser<Guid>
    {
        [Display(Name = "Ad-Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        public required string Name { get; set; }

    }
}
