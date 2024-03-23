using StarBank.Domain.Models;
namespace StarBank.Domain.DTOs;

public class PersonPhysicalDto : Person
{
    public string Name { get; set; }
    public string BirthDate { get; set; }
    public double MonthlyIncome { get; set; }
}