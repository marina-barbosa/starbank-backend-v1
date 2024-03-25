
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using starbank_api.Domain;
using starbank_api.Domain.Models;
using starbank_api.Domain.Services;

namespace starbank_api.Controllers;

[ApiController]
[Route("v1/transactions")]
[Authorize]

public class TransactionController : ControllerBase
{

    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly StarDbContext _context;
    private readonly TokenServices _tokenServices;
    private readonly IMapper _mapper;


    public TransactionController(TokenServices tokenServices, IMapper mapper, IHttpContextAccessor httpContextAccessor, StarDbContext context)
    {

        _httpContextAccessor = httpContextAccessor;
        _context = context;
        _tokenServices = tokenServices;
        _mapper = mapper;
    }




    [HttpPost("transferAccountToAccount")]
    public async Task<ActionResult<Transation>> Transfer(TransferAccountToAccountRequestDto transactionRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Transation newTransaction = _mapper.Map<Transation>(transactionRequest);
        var customerOriginId = int.Parse(_tokenServices.ExtractIdToken());

        if (customerOriginId == transactionRequest.TargetCustomerId)
        {
            return BadRequest("Origem e Destino devem ser diferentes.");
        }

        var accountOrigin = await _context.Accounts
            .FirstOrDefaultAsync(acc => acc.CustomerId == customerOriginId);


        if (accountOrigin == null)
        {
            return BadRequest("Conta de origem inexistente");
        }

        if (accountOrigin.BalanceInCents < newTransaction.ValueInCents)
        {
            return BadRequest("Saldo insuficiente");
        }

        var targetExist = await _context.Accounts
            .FirstOrDefaultAsync(acc => acc.CustomerId == newTransaction.TargetCustomerId);

        if (targetExist == null)
        {
            return BadRequest("Conta de destino inexistente");
        }

        accountOrigin.BalanceInCents -= newTransaction.ValueInCents;
        _context.Accounts.Update(accountOrigin);
        await _context.SaveChangesAsync();

        targetExist.BalanceInCents += newTransaction.ValueInCents;
        _context.Accounts.Update(targetExist);
        await _context.SaveChangesAsync();

        _context.Transations.Add(newTransaction);
        await _context.SaveChangesAsync();

        // return Ok(newTransaction);
        return CreatedAtAction(nameof(GetTransactionById), new { id = newTransaction.Id }, newTransaction);
    }










    [HttpPost("register")]
    public async Task<ActionResult<Transation>> RegisterTransaction()
    {

        var transation = new Transation
        {
            OriginCustomerId = 5,
            TargetCustomerId = 6,
            TransactionDate = DateTime.Now,
            ValueInCents = 103,
            TransactionType = TransactionType.Credit,
            DescriptionJson = "Transaferencia Pix"
        };

        if (transation.OriginCustomerId == transation.TargetCustomerId)
        {
            return BadRequest("Origem e Destino devem ser diferentes.");
        }

        _context.Transations.Add(transation);
        await _context.SaveChangesAsync();

        return transation;
    }

    [HttpGet("getall")]
    public async Task<ActionResult<List<Transation>>> GetAllTransactions()
    {
        var customerId = _tokenServices.ExtractIdToken();
        var id = int.Parse(customerId);

        var transactions = await _context.Transations
                                        .Where(tr => tr.OriginCustomerId == id || tr.TargetCustomerId == id)
                                        .ToListAsync();

        return transactions;
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Transation>> GetTransactionById(int id)
    {
        var transation = await _context.Transations.FindAsync(id);
        if (transation == null)
        {
            return NotFound();
        }
        return Ok(transation);
    }


}





