
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using starbank_api.Domain;
using starbank_api.Domain.Models;

namespace starbank_api.Controllers;



[ApiController]
[Route("v1/customer")]
public class RegistraContaPjController : ControllerBase
{
    private readonly StarDbContext _context;
    private readonly IMapper _mapper;




    public RegistraContaPjController(StarDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public class RegistraContaPjRequestDto
    {
        public CustomerRequestDto? CustomerRequest { get; set; }
        public AddressRequestDto? AddressRequest { get; set; }
        public LegalEntityRequestDto? LegalEntityRequest { get; set; }
        public AccountRequestDto? AccountRequest { get; set; }
    }

    public class RegistraContaPjResponseDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public ClientType ClientType { get; set; }
        public bool ActiveAccount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public AccountType AccountType { get; set; }
        public string? Number { get; set; }
        public string? Agency { get; set; }
        public string? Cnpj { get; set; }
    }


    [HttpPost("registracontapj")]
    public async Task<ActionResult<Customer>> RegistraContaPj([FromBody] RegistraContaPjRequestDto registraContaPjRequestDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (registraContaPjRequestDto.CustomerRequest != null)
        {
            registraContaPjRequestDto.CustomerRequest.LoginPassword = BCrypt.Net.BCrypt.HashPassword(registraContaPjRequestDto.CustomerRequest.LoginPassword);
        }
        else
        {
            return BadRequest("CustomerRequest não pode ser nulo.");
        }

        Customer newCustomer = _mapper.Map<Customer>(registraContaPjRequestDto.CustomerRequest);
        Address newAddress = _mapper.Map<Address>(registraContaPjRequestDto.AddressRequest);
        LegalEntity newLegalEntity = _mapper.Map<LegalEntity>(registraContaPjRequestDto.LegalEntityRequest);
        Account newAccount = _mapper.Map<Account>(registraContaPjRequestDto.AccountRequest);

        newCustomer.AcceptedTerm = true;
        newCustomer.ActiveAccount = true;
        newCustomer.CreatedAt = DateTime.Now;
        newCustomer.UpdatedAt = DateTime.Now;

        try
        {
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            var customerResponseDto = _mapper.Map<CustomerResponseDto>(newCustomer);
            var response = CreatedAtAction("GetCustomer", new { id = newCustomer.Id }, customerResponseDto);


            newLegalEntity.CustomerId = newCustomer.Id;
            _context.LegalEntities.Add(newLegalEntity);
            await _context.SaveChangesAsync();


            newAddress.CustomerId = newCustomer.Id;
            _context.Addresses.Add(newAddress);
            await _context.SaveChangesAsync();


            newAccount.CustomerId = newCustomer.Id;
            newAccount.Agency = "0001";
            newAccount.BalanceInCents = 0;

            string customerId = newCustomer.Id.ToString();
            string cnpjFirstFourDigits = newLegalEntity.Cnpj[..4];
            newAccount.Number = customerId + cnpjFirstFourDigits;


            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();



            var customerResponseWithAccountDto = new RegistraContaPjResponseDto
            {
                Name = newCustomer.Name,
                Email = newCustomer.Email,
                ClientType = newCustomer.ClientType,
                ActiveAccount = newCustomer.ActiveAccount,
                CreatedAt = newCustomer.CreatedAt,
                AccountType = newAccount.AccountType,
                Number = newAccount.Number,
                Agency = newAccount.Agency,
                Cnpj = newLegalEntity.Cnpj
            };

            return Ok(customerResponseWithAccountDto);

        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }



    }
}