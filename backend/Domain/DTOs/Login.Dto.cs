namespace StarPay.Domain.DTOs;
public class LoginDto
{
    [required]
    [CpfCnpj]
    public string CpfCnpj { get; set; }

    [required]
    public string Password { get; set; }
}