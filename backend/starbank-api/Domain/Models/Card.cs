using System.ComponentModel.DataAnnotations;

namespace starbank_api.Domain.Models;

public class Card : Entity
{
    [Required]
    public int AccountId { get; set; }

    [Required]
    [StringLength(16)]
    public required string CardNumber { get; set; }

    [Required]
    public DateTime ExpirationDate { get; set; }

    [Required]
    [StringLength(10)]
    public required string CardType { get; set; }
}