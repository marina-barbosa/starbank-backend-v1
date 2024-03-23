using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StarBank.Controllers;

[ApiController]
[Route("v1/account")]

public class AccountController : ControllerBase
{
    private readonly AppDbContext _context;


    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    // [HttpPost("register")]
    // public async Task<ActionResult<Account>> Register(Account account)
    // {

    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }

    //     try
    //     {
    //         _context.Accounts.Add(account);
    //         await _context.SaveChangesAsync();

    //         return Ok("Account Created!");
    //     }
    //     catch (System.Exception)
    //     {
    //         return StatusCode(500, "Erro interno do servidor.");
    //     }
    // }

    // [HttpGet("information")]
    // public IActionResult GetById()
    // {

    //     var accountProfiles = accounts.Select(account => new Account()
    //     {
    //         Id = account.Id,
    //         Number = account.Number,
    //         Agency = account.Agency,
    //         AccountType = account.AccountType,
    //         Balance = account.Balance,
    //         KeyPix = account.KeyPix,
    //         PasswordTransaction = account.PasswordTransaction,
    //         ConfirmPasswordTransaction = account.ConfirmPasswordTransaction
    //     });

    //     return Ok(accountProfiles);
    // }

    // GET: /api/saldo
    // [Authorize]
    // [HttpGet("balance")]
    // public ActionResult<decimal> GetSaldo()
    // {
    //     var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        
    //     var id = ExtractIdToken(token);
    //     // Recupera o ID do cliente a partir do token JWT
    //     var idCustomer = int.Parse(User.FindFirst(id).Value);

    //     // Busca a conta do cliente pelo ID
    //     var account = _context.Accounts.FirstOrDefault(x => x.CustomerId == idCustomer);

    //     if (account == null)
    //     {
    //         // Se a conta não for encontrada, retorna um erro 404 - Not Found
    //         return NotFound("Conta não encontrada");
    //     }

    //     // Retorna o saldo da conta do cliente com um status 200 - OK
    //     return Ok(account.Balance);
    // }
}




// public static List<Account> accounts = new(){
//     new(){
//         Id = 0,
//         CustomerId = 1,
//         Number = "1245-85",
//         Agency = "243-2",
//         AccountType = 0,
//         Balance = 211045.65,
//         KeyPix = "12345678901234567890",
//         PasswordTransaction = "starbank123",
//         ConfirmPasswordTransaction = "starbank123"
//     },
// };