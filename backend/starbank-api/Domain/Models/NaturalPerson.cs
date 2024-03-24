using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace starbank_api.Domain.Models;

public class NaturalPerson : Entity
{
    public required Customer Customer { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(14)]
    public required string Cpf { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [Range(0, 99999999999999.99)]
    public decimal MonthlyIncome { get; set; }
}