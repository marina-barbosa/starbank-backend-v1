using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace starbank_api.Domain.Models;
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
    [Required]
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
    [Range(0, 99999999999999)]
    public int BalanceInCents { get; set; }

    [StringLength(50)]
    public required string KeyPix { get; set; }

    [Required]
    [StringLength(100)]
    [DataType(DataType.Password)]
    public required string PasswordTransaction { get; set; }

    [Required]
    [Compare("PasswordTransaction")]
    public required string ConfirmPasswordTransaction { get; set; }
}