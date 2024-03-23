using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StarBank.Models; // Supondo que Cartao e BancoDbContext estejam definidos neste namespace

namespace StarBank.Controllers
{
    [Authorize] // Verifica se o usuário está autenticado através do JWT
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        private readonly StarDbContext _dbContext;

        public CartaoController(BancoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: /api/cartao
        [HttpGet]
        public ActionResult<Cartao> GetCartao()
        {
            // Recupera o ID do cliente a partir do token JWT
            var clienteId = int.Parse(User.FindFirst("id").Value);

            // Busca o cartão do cliente pelo ID
            var cartao = _dbContext.Cartoes.FirstOrDefault(c => c.ClienteId == clienteId);

            if (cartao == null)
            {
                // Se o cartão não for encontrado, retorna um erro 404 - Not Found
                return NotFound("Cartão não encontrado");
            }

            // Retorna os detalhes do cartão com um status 200 - OK
            return Ok(cartao);
        }
    }
}
