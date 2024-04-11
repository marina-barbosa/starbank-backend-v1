using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace starbank_api.Domain.Models;

public class Address : Entity
{
    [Required]
    public int CustomerId { get; set; }

    [StringLength(100)]
    public required string Street { get; set; }

    [StringLength(100)]
    public required string City { get; set; }

    [StringLength(50)]
    public required string State { get; set; }

    [StringLength(10)]
    public required string ZipCode { get; set; }

    [StringLength(100)]
    public required string Country { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; } = DateTime.Now;

    public DateTime? DeletedAt { get; set; }


}