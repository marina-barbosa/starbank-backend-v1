using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarBank.Domain.Models;


public enum AccountType
{
    Corrente,
    Poupança,
    Investimento,
    Salário,
    Universitária,
    Conjunta
}

public class Account : Entity
{
    public required Customer Customer { get; set; }
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(20)]
    public required string Number { get; set; }

    [Required]
    [StringLength(20)]
    public required string Agency { get; set; }

    [Required]
    public AccountType AccountType { get; set; }

    [Required]
    [Range(0, 99999999999999.99)]
    public double Balance { get; set; }

    [StringLength(50)]
    public required string KeyPix { get; set; }

    [Required]
    [StringLength(100)]
    [DataType(DataType.Password)]
    public required string PasswordTransaction { get; set; }

    [Required]
    [Compare("Password")]
    public required string ConfirmPasswordTransaction { get; set; }
}

