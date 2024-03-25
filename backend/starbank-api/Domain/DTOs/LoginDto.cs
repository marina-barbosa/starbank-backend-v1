using System.ComponentModel.DataAnnotations.Schema;

namespace starbank_api.Domain.Models;

[NotMapped]
public class LoginModel
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}
