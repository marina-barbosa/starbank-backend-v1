using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarBank.Domain.Models;

public class Card : Entity
{
    [ForeignKey("Account")]
    public int AccountId { get; set; }
    [Required]
    [StringLength(16)]
    public required string NumeroCartao { get; set; }
    [Required]
    public DateTime DataValidade { get; set; }
    [Required]
    [StringLength(10)]
    public required string TipoCartao { get; set; }

    public required Account Account { get; set; }
}