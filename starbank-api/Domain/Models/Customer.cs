using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace starbank_api.Domain.Models;

public class Customer
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public required string Name { get; set; }

    [Required]
    [StringLength(50)]
    public required string Email { get; set; }

    [StringLength(20)]
    public required string Phone { get; set; }

    [Required]
    public ClientType ClientType { get; set; }

    [Required]
    [StringLength(100)]
    public required string LoginPassword { get; set; }

    public bool AcceptedTerm { get; set; } = true;

    public bool ActiveAccount { get; set; } = true;

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public DateTime? DeletedAt { get; set; }

}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ClientType
{
    PF,
    PJ
}