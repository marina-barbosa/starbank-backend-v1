using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarBank.Domain.Models;

public class PessoaJuridica : Entity
{

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(18)]
    public required string Cnpj { get; set; }

    [Required]
    [StringLength(100)]
    public required string NomeFantasia { get; set; }

    [StringLength(100)]
    public required string InscricaoEstadual { get; set; }

    [Required]
    [Range(0, 99999999999999.99)]
    public decimal FaturamentoAnual { get; set; }

    [StringLength(100)]
    public required string Tributacao { get; set; }

    public required Customer Customer { get; set; }
}