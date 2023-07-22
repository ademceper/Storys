using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Story.Data;
using System.ComponentModel.DataAnnotations;

namespace Story.Data;

public class EMail
{
    public Guid Id { get; set; }

    [Display(Name = "Başlık")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    public required string Subject { get; set; }
    [Display(Name = "Mesaj")]
    [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
    public required string Body { get; set; }

    [Display(Name = "Saat")]
    public TimeSpan Time { get; set; }

    [Display(Name = "Durum")]
    public bool Enabled { get; set; }
}

public class EMailTypeConfiguration : IEntityTypeConfiguration<EMail>
{
    public void Configure(EntityTypeBuilder<EMail> builder)
    {

        
          

        
    }
}