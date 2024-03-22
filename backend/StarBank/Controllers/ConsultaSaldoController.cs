using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarBank.Models; // Supondo que Conta e BancoDbContext estejam definidos neste namespace

namespace StarBank.Controllers
{
    [Authorize] // Verifica se o usuário está autenticado através do JWT
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoController : ControllerBase
    {
        private readonly BancoDbContext _dbContext;

        public SaldoController(BancoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: /api/saldo
        [HttpGet]
        public ActionResult<decimal> GetSaldo()
        {
            // Recupera o ID do cliente a partir do token JWT
            var clienteId = int.Parse(User.FindFirst("id").Value);

            // Busca a conta do cliente pelo ID
            var conta = _dbContext.Contas.FirstOrDefault(c => c.ClienteId == clienteId);

            if (conta == null)
            {
                // Se a conta não for encontrada, retorna um erro 404 - Not Found
                return NotFound("Conta não encontrada");
            }

            // Retorna o saldo da conta do cliente com um status 200 - OK
            return Ok(conta.Saldo);
        }
    }
}
