using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService _transferenciaService;

        public TransferenciaController(ITransferenciaService transferenciaService)
        {
            _transferenciaService = transferenciaService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Transferir([FromBody] TransferenciaRequest request)
        {
            try
            {
                // Verificar campos obrigatórios e validação de formato
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Verificar saldo disponível na conta do remetente
                var remetente = _transferenciaService.ObterConta(request.ContaOrigem);
                if (remetente == null)
                {
                    return NotFound("Conta origem não encontrada");
                }

                if (remetente.Saldo < request.Valor)
                {
                    return BadRequest("Saldo insuficiente");
                }

                // Atualizar saldo das contas do remetente e do destinatário
                _transferenciaService.Transferir(request);

                // Registrar na tabela de transações
                _transferenciaService.RegistrarTransacao(request);

                return Ok("Transferência realizada com sucesso");
            }
            catch (Exception ex)
            {
                // Log do erro
                return StatusCode(500, "Erro interno no servidor");
            }
        }
    }
}
