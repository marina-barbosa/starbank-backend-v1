using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using starbank_api.Domain.Services;

namespace starbank_api.Domain.Models;

[ApiController]
[Route("v1/account")]

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

    [HttpPost("register")]
    public async Task<ActionResult<Account>> Register(Account account)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return Ok("Account Created!");
        }
        catch (System.Exception)
        {
            return StatusCode(500, "Erro interno do servidor.");
        }
    }

    [HttpGet("{CustumerId}")]
    // [Authorize]
    public async Task<ActionResult<Account>> GetAccount(int CustumerId)
    {
        var account = await _context.Accounts.FindAsync(CustumerId);
        if (account == null)
        {
            return NotFound();
        }

        return account;
    }


    [Authorize]
    [HttpGet("balance")]
    public ActionResult<decimal> GetBalance()
    {
        var idCustomer = int.Parse(_tokenServices.ExtractIdToken());

        // Busca a conta do cliente pelo ID
        var account = _context.Accounts.FirstOrDefault(x => x.CustomerId == idCustomer);

        if (account == null)
        {
            // Se a conta não for encontrada, retorna um erro 404 - Not Found
            return NotFound("Conta não encontrada");
        }

        // Retorna o saldo da conta do cliente com um status 200 - OK
        return Ok(account.Balance);
    }



    [HttpGet]
    public ActionResult<Card> GetCartao()
    {
        // Recupera o ID do cliente a partir do token JWT
        var idCustomer = int.Parse(_tokenServices.ExtractIdToken());

        // Busca o cartão do cliente pelo ID
        var card = _context.Cards.FirstOrDefault(c => c.AccountId == idCustomer);

        if (card == null)
        {
            // Se o cartão não for encontrado, retorna um erro 404 - Not Found
            return NotFound("Cartão não encontrado");
        }

        // Retorna os detalhes do cartão com um status 200 - OK
        return Ok(card);
    }




    [HttpGet("{id}/balance")]
    public async Task<IActionResult> ConsultarSaldo(int id)
    {
        var account = await _context.Accounts.FindAsync(id);

        if (account == null)
        {
            return NotFound("Conta não encontrada.");
        }

        return Ok(account.Balance);
    }

    [HttpPost("{id}/deposito")]
    public async Task<IActionResult> Deposito(int id, [FromBody] decimal valor)
    {
        var conta = await _context.Accounts.FindAsync(id);

        if (conta == null)
        {
            return NotFound("Conta não encontrada.");
        }

        conta.Balance = (double)((decimal)conta.Balance + valor);


        await _context.SaveChangesAsync();

        return Ok(conta.Balance);
    }

    [HttpPost("{id}/saque")]
    public async Task<IActionResult> Saque(int id, [FromBody] double valor)
    {
        var conta = await _context.Accounts.FindAsync(id);

        if (conta == null)
        {
            return NotFound("Conta não encontrada.");
        }

        if (conta.Balance < valor)
        {
            return BadRequest("Saldo insuficiente.");
        }

        conta.Balance -= valor;
        await _context.SaveChangesAsync();

        return Ok(conta.Balance);
    }



    [HttpPatch("deposito/{id}")]
    public async Task<IActionResult> RealizarDeposito(int id, [FromBody] double valorDeposito)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null)
        {
            return NotFound("Usuário não encontrado.");
        }

        account.Balance += valorDeposito;

        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Depósito realizado com sucesso.", novoSaldo = account.Balance });
    }


    [HttpPatch("saque/{id}")]
    public async Task<IActionResult> RealizarSaque(int id, [FromBody] double valorSaque)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null)
        {
            return NotFound("Usuário não encontrado.");
        }

        if (account.Balance < valorSaque)
        {
            return BadRequest("Saldo insuficiente para realizar o saque.");
        }

        account.Balance -= valorSaque;

        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Saque realizado com sucesso.", novoSaldo = account.Balance });
    }





    [HttpPost]
    public ActionResult PostTransferencia(Transation transation)
    {
        // Verifica se os campos obrigatórios foram fornecidos
        if (transation == null || transation.Value <= 0)
        {
            // Se algum campo obrigatório estiver faltando ou inválido, retorna um erro 400 - Bad Request
            return BadRequest("Campos obrigatórios não fornecidos ou inválidos");
        }

        // Verifica se há saldo disponível na conta de origem
        var contaOrigem = _context.Accounts.Find(transation.OriginCustomerId);
        if (contaOrigem == null || contaOrigem.Balance < transation.Value)
        {
            // Se não houver saldo disponível, retorna um erro 400 - Bad Request
            return BadRequest("Saldo insuficiente na conta de origem");
        }

        // Atualiza o saldo da conta de origem e destino
        contaOrigem.Balance -= transation.Value;
        var contaDestino = _context.Accounts.Find(transation.TargetCustomerId);
        if (contaDestino == null)
        {
            // Se a conta de destino não existir, retorna um erro 400 - Bad Request
            return BadRequest("Conta de destino não encontrada");
        }
        contaDestino.Balance += transation.Value;

        // Salva as alterações no banco de dados
        _context.SaveChanges();

        // Retorna um status 200 - OK para indicar que a transferência foi realizada com sucesso
        return Ok("Transferência realizada com sucesso");
    }








    public class WithdrawalRequest
    {

        public int AccountId { get; set; }
        public double Value { get; set; }
        public string? Password { get; set; }
    }

    [HttpPost]
    [Authorize]
    public IActionResult Withdraw([FromBody] WithdrawalRequest request)
    {
        // Validar campos obrigatórios
        if (request == null || request.AccountId == 0 || request.Value <= 0 || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Campos obrigatórios não foram fornecidos.");
        }

        var account = _context.Accounts.FirstOrDefault(c => c.Id == request.AccountId);

        if (account == null)
        {
            return NotFound("Conta não encontrada");
        }

        if (account.Balance < request.Value)
        {
            return BadRequest("Saldo insuficiente");
        }

        try
        {
            account.Balance -= request.Value;
            _context.SaveChanges();

            var transaction = new Transation
            {
                OriginCustomerId = account.Id,
                Value = -request.Value,
                TransactionDate = DateTime.Now
            };

            _context.Transations.Add(transaction);
            _context.SaveChanges();

            return Ok("Saque realizado com sucesso!");
        }
        catch (UnauthorizedAccessException)
        {
            return StatusCode(401, "Não autorizado");
        }

        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
        }
    }





    [HttpGet("usuario/{usuarioId}/transacao/{transacaoId}")]
    public async Task<ActionResult<Transation>> GetByIdTransacao(int accountId, int transationId)
    {
        var transation = await _context.Transations
            .Where(t => (t.OriginCustomerId == accountId || t.TargetCustomerId == accountId) && t.Id == transationId)
            .FirstOrDefaultAsync();

        if (transation == null)
        {
            return NotFound("Transação não encontrada para o usuário especificado.");
        }

        return transation;
    }

    [HttpGet("transations/{id}")]
    public async Task<ActionResult<IEnumerable<Transation>>> GetAllTransacoes(int id)
    {
        var transations = await _context.Transations
            .Where(t => t.OriginCustomerId == id || t.TargetCustomerId == id)
            .ToListAsync();

        if (!transations.Any())
        {
            return NotFound("Nenhuma transação encontrada para o usuário especificado.");
        }

        return transations;
    }
}