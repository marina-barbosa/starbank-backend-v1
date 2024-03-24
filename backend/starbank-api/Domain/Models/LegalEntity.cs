using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace starbank_api.Domain.Models;

public class LegalEntity : Entity
{

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(18)]
    public required string Cnpj { get; set; }

    [Required]
    [StringLength(100)]
    public required string FantasyName { get; set; }

    [StringLength(100)]
    public required string StateRegistration { get; set; }

    [Required]
    [Range(0, 99999999999999.99)]
    public decimal AnnualBilling { get; set; }

    [StringLength(100)]
    public required string Taxation { get; set; }

    public required Customer Customer { get; set; }
}