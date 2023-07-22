
using System.ComponentModel.DataAnnotations;

namespace Story.Models;

public class RegisterViewModel
{
    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    [DataType(DataType.Text)]
    public required string Name { get; set; }


    [Display(Name = "Email")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

  

   
    public string? ReturnUrl { get; set; }
}
