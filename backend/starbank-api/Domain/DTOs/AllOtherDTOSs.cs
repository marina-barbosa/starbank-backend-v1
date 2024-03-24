using System.ComponentModel.DataAnnotations;

namespace starbank_api.Domain.Models;

public class CardRequestDto
{
}

public class AccountRequestDto
{
    [Required]
    public AccountType AccountType { get; set; }

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

public class AddressRequestDto
{
    [StringLength(100)]
    public required string Street { get; set; }

    [StringLength(100)]
    public required string City { get; set; }

    [StringLength(50)]
    public required string State { get; set; }

    [StringLength(10)]
    public required string ZipCode { get; set; }

    [StringLength(100)]
    public required string Country { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public DateTime? DeletedAt { get; set; }
}

public class PfRequestDto
{
}

public class LegalEntityRequestDto
{
    [Required]
    [StringLength(18)]
    public required string Cnpj { get; set; }

    [Required]
    [StringLength(100)]
    public required string FantasyName { get; set; }

    [StringLength(100)]
    public required string StateRegistration { get; set; }

    [Required]
    [Range(0, 9999999999999999)]
    public int AnnualBillingInCents { get; set; }

    [StringLength(100)]
    public required string Taxation { get; set; }
}

