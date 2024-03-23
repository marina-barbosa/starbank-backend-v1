
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using StarBank.Domain.Models;

public class Customer : Entity
{
    [Required]
    [StringLength(100)]
    public required string Name { get; set; }

    [Required]
    [StringLength(50)]
    public required string Email { get; set; }

    [StringLength(20)]
    public required string Phone { get; set; }

    [Required]
    public TipoCliente TipoCliente { get; set; }

    [Required]
    [StringLength(100)]
    public required string SenhaLogin { get; set; }

    [Required]
    public bool TermoAceito { get; set; } = true;

    [Required]
    public bool ContaAtiva { get; set; } = true;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CriadoEm { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdateAt { get; set; }

    public DateTime? DeletadoEm { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoCliente
{
    PF,
    PJ
}