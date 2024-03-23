using System.ComponentModel.DataAnnotations;
namespace StarBank.Domain.DTOs

{
    public class RegisterDto
    {
        [Required]
        public string CpfCnpj { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}