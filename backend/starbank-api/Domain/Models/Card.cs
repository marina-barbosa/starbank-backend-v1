using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace starbank_api.Domain.Models;

public class Card : Entity
{
    [ForeignKey("Account")]
    public int AccountId { get; set; }
    [Required]
    [StringLength(16)]
    public required string CardNumber { get; set; }
    [Required]
    public DateTime ExpirationDate { get; set; }
    [Required]
    [StringLength(10)]
    public required string CardType { get; set; }

    public required Account Account { get; set; }
}