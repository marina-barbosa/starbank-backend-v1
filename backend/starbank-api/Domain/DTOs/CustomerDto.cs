using System.ComponentModel.DataAnnotations;

namespace starbank_api.Domain.Models;


public class CustomerRequestDto
{
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required]
    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    [Required]
    public ClientType ClientType { get; set; }

    [Required]
    [StringLength(100)]
    public string? LoginPassword { get; set; }

}


public class CustomerResponseDto
{
    [Required]
    [StringLength(100)]
    public string? Name { get; set; }

    [Required]
    [StringLength(50)]
    public string? Email { get; set; }

    [Required]
    public ClientType ClientType { get; set; }

    [Required]
    public bool ActiveAccount { get; set; }

    public DateTime CreatedAt { get; set; }

}
