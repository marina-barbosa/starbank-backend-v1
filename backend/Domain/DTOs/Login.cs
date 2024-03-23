using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class LoginModel
{
    public string Email { get; set; }
    public string Senha { get; set; }
}
