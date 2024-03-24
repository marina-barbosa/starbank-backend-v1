using System.ComponentModel.DataAnnotations.Schema;

namespace starbank_api.Domain.Models;

[NotMapped]
public class ClaimsModel
{
    public int Id { get; set; }
    public string? Email { get; set; }
}