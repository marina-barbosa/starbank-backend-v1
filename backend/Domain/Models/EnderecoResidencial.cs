
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarBank.Domain.Models;


public class EnderecoResidencial : Entity
{

    public int CustomerId { get; set; }

    [StringLength(100)]
    public required string Rua { get; set; }

    [StringLength(100)]
    public required string Cidade { get; set; }

    [StringLength(50)]
    public required string Estado { get; set; }

    [StringLength(10)]
    public required string Cep { get; set; }

    [StringLength(100)]
    public required string Pais { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CriadoEm { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime AtualizadoEm { get; set; }

    public DateTime? DeletadoEm { get; set; }

    // Propriedade de navegação para o usuário
    [ForeignKey("CustomerId")]
    public virtual required Customer Customer { get; set; }
}
