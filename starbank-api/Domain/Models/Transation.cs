using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace starbank_api.Domain.Models;

public class Transation : Entity
{

    [Required]
    public int OriginCustomerId { get; set; }

    public int TargetCustomerId { get; set; }

    public DateTime TransactionDate { get; set; }

    public int ValueInCents { get; set; }

    public TransactionType TransactionType { get; set; }

    [Column(TypeName = "json")]
    public string? DescriptionJson { get; set; }

}

public enum TransactionType
{
    Debit,
    Credit,
    TED,
    Pix,
    Transfer,
    PaymentSlip,
    Deposit,
    Withdraw,
    DebitCard,
    CreditCard
}