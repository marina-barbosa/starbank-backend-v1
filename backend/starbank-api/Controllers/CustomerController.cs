

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace starbank_api.Domain.Models;


[ApiController]
[Route("v1/customer")]
public class CustomerController : ControllerBase
{
    private readonly StarDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _appSettings;




    public CustomerController(StarDbContext context, IMapper mapper, IConfiguration appSettings)
    {
        _context = context;
        _mapper = mapper;
        _appSettings = appSettings;
    }




    [HttpPost("register")]
    public async Task<ActionResult<Customer>> Register(CustomerRequestDto customerRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        customerRequest.LoginPassword = BCrypt.Net.BCrypt.HashPassword(customerRequest.LoginPassword);

        Customer newCustomer = _mapper.Map<Customer>(customerRequest);

        newCustomer.AcceptedTerm = true;
        newCustomer.ActiveAccount = true;
        newCustomer.CreatedAt = DateTime.Now;
        newCustomer.UpdatedAt = DateTime.Now;

        try
        {
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();

        }
        catch (DbUpdateException ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }

        var customerResponseDto = _mapper.Map<CustomerResponseDto>(newCustomer);
        return CreatedAtAction("GetCustomer", new { id = newCustomer.Id }, customerResponseDto);
    }





    [HttpGet("{id}")]
    // [Authorize]
    public async Task<ActionResult<CustomerResponseDto>> GetCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        CustomerResponseDto customerResponse = _mapper.Map<CustomerResponseDto>(customer);
        return Ok(customerResponse);
    }




    [HttpPost("address")]
    public IActionResult AddressRegister(Address newAddress)
    {
        _context.Addresses.Add(newAddress);
        _context.SaveChanges();

        return Ok("Created!");
    }

    [HttpPost("account")]
    public IActionResult CreateAccount(Account newAccount)
    {
        _context.Accounts.Add(newAccount);
        _context.SaveChanges();

        return Ok("Created!");
    }

    [HttpPost("card")]
    public IActionResult CreateCard(Card newCard)
    {
        _context.Cards.Add(newCard);
        _context.SaveChanges();

        return Ok("Created!");
    }

    [HttpPost("legalentity")]
    public IActionResult CreateLegalEntity(LegalEntity newLegalEntity)
    {
        _context.LegalEntities.Add(newLegalEntity);
        _context.SaveChanges();

        return Ok("Created!");
    }

    [HttpPost("naturalperson")]
    public IActionResult CreateNaturalPerson(NaturalPerson newNaturalPerson)
    {
        _context.NaturalPersons.Add(newNaturalPerson);
        _context.SaveChanges();

        return Ok("Created!");
    }


    //     // [HttpPost("pf/cadastro")]
    //     // public async Task<IActionResult> CadastrarPessoaFisica([FromBody] PessoaFisica pessoaFisica)
    //     // {
    //     //     if (!ModelState.IsValid)
    //     //     {
    //     //         return BadRequest(ModelState);
    //     //     }

    //     //     try
    //     //     {
    //     //         _context.PessoasFisicas.Add(pessoaFisica);
    //     //         await _context.SaveChangesAsync();
    //     //         return Ok(pessoaFisica);
    //     //     }
    //     //     catch (DbUpdateException)
    //     //     {
    //     //         return BadRequest("Não foi possível salvar a Pessoa Física.");
    //     //     }
    //     // }


    //     // [HttpPost("pj/cadastro")]
    //     // public async Task<IActionResult> CadastrarPessoaJuridica([FromBody] PessoaJuridica pessoaJuridica)
    //     // {
    //     //     if (!ModelState.IsValid)
    //     //     {
    //     //         return BadRequest(ModelState);
    //     //     }

    //     //     try
    //     //     {
    //     //         _context.PessoasJuridicas.Add(pessoaJuridica);
    //     //         await _context.SaveChangesAsync();
    //     //         return Ok(pessoaJuridica);
    //     //     }
    //     //     catch (DbUpdateException)
    //     //     {
    //     //         return BadRequest("Não foi possível salvar a Pessoa Jurídica.");
    //     //     }
    //     // }

    //     // [HttpPost("conta")]
    //     // public async Task<IActionResult> CadastrarConta([FromBody] Conta conta)
    //     // {
    //     //     if (!ModelState.IsValid)
    //     //     {
    //     //         return BadRequest(ModelState);
    //     //     }

    //     //     try
    //     //     {
    //     //         _context.Contas.Add(conta);
    //     //         await _context.SaveChangesAsync();
    //     //         return Ok(conta);
    //     //     }
    //     //     catch (DbUpdateException)
    //     //     {
    //     //         return BadRequest("Não foi possível salvar a Conta.");
    //     //     }
    //     // }

    //     // [HttpPost("cartao")]
    //     // public async Task<IActionResult> CadastrarCartao([FromBody] Cartao cartao)
    //     // {
    //     //     if (!ModelState.IsValid)
    //     //     {
    //     //         return BadRequest(ModelState);
    //     //     }

    //     //     try
    //     //     {
    //     //         _context.Cartoes.Add(cartao);
    //     //         await _context.SaveChangesAsync();
    //     //         return Ok(cartao);
    //     //     }
    //     //     catch (DbUpdateException)
    //     //     {
    //     //         return BadRequest("Não foi possível salvar o Cartão.");
    //     //     }
    //     // }





}
