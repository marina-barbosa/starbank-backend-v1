using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class ClaimsModel
{
    public int Id { get; set; }
    public string Email { get; set; }
}