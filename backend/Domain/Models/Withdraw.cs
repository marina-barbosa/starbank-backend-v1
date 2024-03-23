using System.ComponentModel.DataAnnotations;

namespace StarBank.Domain.Models;

public class WithdrawalRequest
{
    [Required]
    public int AccountId { get; set; }
    public double Value { get; set; }
    public string? Password { get; set; }

}
 