using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StarBank.Controllers
{
    [Authorize] // Verifica se o usuário está autenticado através do JWT
    [Route("api/[controller]")]
    [ApiController]
    public class GetCustomerController : ControllerBase
    {
        //     private readonly BancoDbContext _dbContext;

        //     public ClienteController(BancoDbContext dbContext)
        //     {
        //         _dbContext = dbContext;
        //     }

        //     // GET: /api/cliente
        //     [HttpGet]
        //     public ActionResult<Cliente> GetCliente()
        //     {
        //         // Recupera o ID do cliente a partir do token JWT
        //         var clienteId = int.Parse(User.FindFirst("id").Value);

        //         // Busca o cliente pelo ID
        //         var cliente = _dbContext.Clientes.Find(clienteId);

        //         if (cliente == null)
        //         {
        //             // Se o cliente não for encontrado, retorna um erro 404 - Not Found
        //             return NotFound("Cliente não encontrado");
        //         }

        //         // Retorna os detalhes do cliente com um status 200 - OK
        //         return Ok(cliente);
        //     }
    }
}
