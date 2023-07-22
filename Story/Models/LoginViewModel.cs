using System.ComponentModel.DataAnnotations;

namespace Story.Models;

public class LoginViewModel
{
    [Display(Name = "E-Posta")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta yazınız!")]
    public string? UserName { get; set; }

    [Display(Name = "Parola")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Oturum Açık Kalsın")]
    public bool IsPersistent { get; set; }

    public string? ReturnUrl { get; set; }

}
