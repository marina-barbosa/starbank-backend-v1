using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace starbank_api.Domain.Models;

public class NaturalPerson : Entity
{
    [Required]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(14)]
    public required string Cpf { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [Range(0, 99999999999999)]
    public int MonthlyIncomeInCents { get; set; }
}