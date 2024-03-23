using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarBank.Domain.Models;
public class PessoaFisica : Entity
{
    public required Customer Customer { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(14)]
    public required string Cpf { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [Range(0, 99999999999999.99)]
    public decimal RendaMensal { get; set; }
}