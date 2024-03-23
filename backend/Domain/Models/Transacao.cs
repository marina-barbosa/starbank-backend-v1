
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StarBank.Domain.Models;

public class Transacao : Entity
{

    [Required]
    public int CustomerOrigemId { get; set; }

    public int CustomerDestinoId { get; set; }

    public DateTime DataTransacao { get; set; }

    public decimal Valor { get; set; }

    public TipoTransacao TipoTransacao { get; set; }

    [Column(TypeName = "json")]
    public string? DescricaoJson { get; set; }

    [ForeignKey("CustomerOrigemId")]
    public virtual required Customer CustomerOrigem { get; set; }

    [ForeignKey("CustomerDestinoId")]
    public virtual Customer? CustomerDestino { get; set; }
}

public enum TipoTransacao
{
    Debito,
    Credito,
    TED,
    Pix,
    Transferencia,
    PagamentoBoleto,
    Deposito,
    Saque,
    CartaoDebito,
    CartaoCredito
}