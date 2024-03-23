namespace StarBank.Domain.Models;

public class Account
{
    public int Id { get; set; }
    public string Number { get; set; }
    public string Agency { get; set; }
    public string AccountType { get; set; }
    public double Balance { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}