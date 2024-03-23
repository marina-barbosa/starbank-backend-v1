using StarBank.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using StarBank.Domain.DTOs;

namespace StarBank.Controllers;

[ApiController] 
[Route("starBank")]

public class RegisterPersonController : ControllerBase
{
    public static List<PersonPhysicalDto> physicalPeople = new(){
        new(){
            Id = 1,
            Name = "Wanderson",
            BirthDate = "2001-06-24",
            MonthlyIncome = 50.5,
            Email = "wanderson@email.com",
            Telephone = "89999175800",
            Road = "Rua Augusta",
            Number = "09A",
            Complement = "Prox. Subway",
            Neighborhood = "Centro",
            City = "Corrente",
            Cep = "64980-000"
        },
    };


    [HttpPost("register/personPhysical")]
    public IActionResult RegisterpersonPhysical(PersonPhysicalDto personPhysicalDto){
        physicalPeople.Add(personPhysicalDto);

        return Ok("Person Physical Created!");
    }

    [HttpGet("information/personPhysical")]
    public IActionResult GetPersonPhysicalDto(){

        var personProfiles = physicalPeople.Select(person => new PersonPhysicalDto(){
            Id = person.Id,
            Name = person.Name,
            BirthDate = person.BirthDate,
            MonthlyIncome = person.MonthlyIncome,
            Email = person.Email,
            Telephone = person.Telephone,
            Road = person.Road,
            Number = person.Number,
            Complement = person.Complement,
            Neighborhood = person.Neighborhood,
            City = person.City,
            Cep = person.Cep
        });

        return Ok(personProfiles);
    }

    public static List<PersonLegalDto> peopleLegal = new(){
        new(){
            Id = 2,
            CorporateReason = "Duarte Ltda",
            Cnpj = "12.145.0001/24",
            StateRegistration = "24062001",
            AnnualBilling = 1.400,
            Taxation = "500",
            Email = "wanderson@email.com",
            Telephone = "89999175812",
            Road = "Rua Augusta",
            Number = "09A",
            Complement = "Prox. Subway",
            Neighborhood = "Centro",
            City = "Corrente",
            Cep = "64980-000"
        },
    };


    [HttpPost("register/personLegal")]
    public IActionResult CadastroPessoaJurica(PersonLegalDto personLegalDto){
        peopleLegal.Add(personLegalDto);

        return Ok("Person Legal Created!");
    }

    [HttpGet("information/personLegal")]
    public IActionResult GetPersonLegal(){

        var personProfiles = peopleLegal.Select(person => new PersonLegalDto(){
            Id = person.Id,
            CorporateReason = person.CorporateReason,
            Cnpj = person.Cnpj,
            StateRegistration = person.StateRegistration,
            AnnualBilling = person.AnnualBilling,
            Taxation = person.Taxation,
            Email = person.Email,
            Telephone = person.Telephone,
            Road = person.Road,
            Number = person.Number,
            Complement = person.Complement,
            Neighborhood = person.Neighborhood,
            City = person.City,
            Cep = person.Cep
        });

        return Ok(personProfiles);
    }


}