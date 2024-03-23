using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_banco_digital.Domain.Dtos;


public class UsuarioRequestDto
{
    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Required]
    [StringLength(50)]
    public string Email { get; set; }

    [StringLength(20)]
    public string Telefone { get; set; }

    [Required]
    public TipoCliente TipoCliente { get; set; }

    [Required]
    [StringLength(100)]
    public string SenhaLogin { get; set; }

}


public class UsuarioResponseDto
{
    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Required]
    [StringLength(50)]
    public string Email { get; set; }

    [Required]
    public TipoCliente TipoCliente { get; set; }

    [Required]
    public bool ContaAtiva { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CriadoEm { get; set; }

}

