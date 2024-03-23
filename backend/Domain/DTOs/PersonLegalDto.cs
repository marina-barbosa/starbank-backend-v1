using StarBank.Domain.Models;
namespace StarBank.Domain.DTOs;

public class PersonLegalDto : Person
{
    public string CorporateReason { get; set; }
    public string Cnpj { get; set; }
    public string StateRegistration { get; set; }
    public double AnnualBilling { get; set; }
    public string Taxation { get; set; }
}