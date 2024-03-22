using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarBank.Models; // Supondo que Transferencia e BancoDbContext estejam definidos neste namespace

namespace StarBank.Controllers
{
    [Authorize] // Verifica se o usuário está autenticado através do JWT
    [Route("api/[controller]")]
    [ApiController]
    public class TransferenciaController : ControllerBase
    {
        private readonly BancoDbContext _dbContext;

        public TransferenciaController(BancoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: /api/transferencia
        [HttpPost]
        public ActionResult PostTransferencia(Transferencia transferencia)
        {
            // Verifica se os campos obrigatórios foram fornecidos
            if (transferencia == null || transferencia.ContaOrigem == null || transferencia.ContaDestino == null || transferencia.Valor <= 0)
            {
                // Se algum campo obrigatório estiver faltando ou inválido, retorna um erro 400 - Bad Request
                return BadRequest("Campos obrigatórios não fornecidos ou inválidos");
            }

            // Verifica se há saldo disponível na conta de origem
            var contaOrigem = _dbContext.Contas.Find(transferencia.ContaOrigem);
            if (contaOrigem == null || contaOrigem.Saldo < transferencia.Valor)
            {
                // Se não houver saldo disponível, retorna um erro 400 - Bad Request
                return BadRequest("Saldo insuficiente na conta de origem");
            }

            // Atualiza o saldo da conta de origem e destino
            contaOrigem.Saldo -= transferencia.Valor;
            var contaDestino = _dbContext.Contas.Find(transferencia.ContaDestino);
            if (contaDestino == null)
            {
                // Se a conta de destino não existir, retorna um erro 400 - Bad Request
                return BadRequest("Conta de destino não encontrada");
            }
            contaDestino.Saldo += transferencia.Valor;

            // Registra a transação
            _dbContext.Transacoes.Add(new Transacao
            {
                ContaOrigem = transferencia.ContaOrigem,
                ContaDestino = transferencia.ContaDestino,
                Valor = transferencia.Valor,
                Data = DateTime.Now
            });
            
            // Salva as alterações no banco de dados
            _dbContext.SaveChanges();

            // Retorna um status 200 - OK para indicar que a transferência foi realizada com sucesso
            return Ok("Transferência realizada com sucesso");
        }
    }
}
