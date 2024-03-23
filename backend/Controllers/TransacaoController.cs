using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_banco_digital.Controllers
{
    [ApiController]
    [Route("v1/transacao")]
    public class TransacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> CadastrarTransacao([FromBody] Transacao transacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Transacoes.Add(transacao);
                await _context.SaveChangesAsync();
                return Ok(transacao);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Não foi possível registrar a transação.");
            }
        }
    }
}