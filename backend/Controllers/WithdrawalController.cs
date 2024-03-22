using Microsoft.AspNetCore.Mvc;

namespace StarBank.Controllers;

[ApiController]
[Route("[withdraw]")]
public class WithdrawController : ControllerBase
{
    [HttpPost]
    [Authorize]
    public IActionResult Withdraw([FromBody] WithdrawalRequest request)
    {
        // Validar campos obrigatórios
        if (request == null || request.AccountId == 0 || request.Value <= 0 || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Campos obrigatórios não foram fornecidos.");
        }

        var account = _context.Account.FirstOrDefault(c => c.Id == request.AccountId);
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
            // Verificar a senha usando JWT (exemplo)
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var userId = JWTService.GetUserIdFromToken(token); // Implemente este método de acordo com a sua lógica de JWT
            var user = _context.Client.FirstOrDefault(u => u.Id == userId);

            if (user == null || user.Password != request.Password)
            {
                return Unauthorized("Senha inválida");
            }

            account.Balance -= request.Value;
            _context.SaveChanges();

                var transaction = new Transaction
            {
                AccountId = account.Id,
                Amount = -request.Value,
                Date = DateTime.Now
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return Ok("Saque realizado com sucesso!");
        }
        catch (UnauthorizedAccessException)
        {
            return StatusCode(401, "Não autorizado"); 
        }
        catch (ForbiddenAccessException)
        {
            return StatusCode(403, "Proibido"); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Erro interno do servidor."); 
        }
        catch (Exception ex)
        {
            return BadRequest("Erro ao processar saque.");
        }
    }
}

