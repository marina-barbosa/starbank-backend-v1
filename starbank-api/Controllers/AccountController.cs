using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using starbank_api.Domain;
using starbank_api.Domain.Services;

namespace starbank_api.Controllers;

[ApiController]
[Route("v1/account")]
[Authorize]

public class AccountController : ControllerBase
{
    private readonly StarDbContext _context;
    private readonly IMapper _mapper;
    private readonly TokenServices _tokenServices;


    public AccountController(StarDbContext context, IMapper mapper, TokenServices tokenServices)
    {
        _context = context;
        _mapper = mapper;
        _tokenServices = tokenServices;
    }



    [HttpGet("customer")]

    public async Task<ActionResult<string>> GetCustomer()
    {
        var customerEmail = _tokenServices.ExtractEmailToken();
        var customerLogedIn = await _context.Customers.FirstOrDefaultAsync(c => c.Email == customerEmail);
        if (customerLogedIn == null)
        {
            return NotFound();
        }

        return Ok(customerLogedIn);
    }

    [HttpGet("account")]
    public async Task<ActionResult<string>> GetAccount()
    {
        var customerId = _tokenServices.ExtractIdToken();
        var id = int.Parse(customerId);
        // var accCustomerLogedIn = await _context.Accounts.FindAsync(customerId);
        var accCustomerLogedIn = await _context.Accounts.FirstOrDefaultAsync(acc => acc.CustomerId == id);
        if (accCustomerLogedIn == null)
        {
            return NotFound();
        }

        return Ok(accCustomerLogedIn);

    }

    [HttpGet("balance")]
    public async Task<ActionResult<string>> GetBalance()
    {
        var customerId = _tokenServices.ExtractIdToken();
        var id = int.Parse(customerId);
        // var accCustomerLogedIn = await _context.Accounts.FindAsync(customerId);
        var accCustomerLogedIn = await _context.Accounts.FirstOrDefaultAsync(acc => acc.CustomerId == id);
        if (accCustomerLogedIn == null)
        {
            return NotFound();
        }

        return Ok(accCustomerLogedIn.BalanceInCents);

    }

    [HttpPost("deposit")]
    public async Task<ActionResult<string>> Deposit([FromBody]int value)
    {
        var customerId = _tokenServices.ExtractIdToken();
        var id = int.Parse(customerId);
        var accCustomerLogedIn = await _context.Accounts.FirstOrDefaultAsync(acc => acc.CustomerId == id);
        if (accCustomerLogedIn == null)
        {
            return NotFound();
        }

        var balance = accCustomerLogedIn.BalanceInCents += value;
        _context.Accounts.Update(accCustomerLogedIn);
        await _context.SaveChangesAsync();

        return Ok(balance);

    }

    [HttpPost("withdraw")]
    public async Task<ActionResult<string>> Withdraw([FromBody]int value)
    {
        var customerId = _tokenServices.ExtractIdToken();
        var id = int.Parse(customerId);
        var accCustomerLogedIn = await _context.Accounts.FirstOrDefaultAsync(acc => acc.CustomerId == id);
        if (accCustomerLogedIn == null)
        {
            return NotFound();
        }

        if (accCustomerLogedIn.BalanceInCents < value)
        {
            return BadRequest("Saldo Inssuficiente");
        }

        var balance = accCustomerLogedIn.BalanceInCents -= value;
        _context.Accounts.Update(accCustomerLogedIn);
        await _context.SaveChangesAsync();

        return Ok(balance);

    }


}