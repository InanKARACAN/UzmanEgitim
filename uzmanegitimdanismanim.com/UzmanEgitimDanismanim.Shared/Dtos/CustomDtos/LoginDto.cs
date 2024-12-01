using System.ComponentModel.DataAnnotations;

namespace UzmanEgitimDanismanim.Shared.Dtos.CustomDtos
{
    public class LoginDto
    {
        [Display(Name = "EPosta")]
        [Required(ErrorMessage = "E-mail bilginizi giriniz.")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
