using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;// Supondo que Conta e BancoDbContext estejam definidos neste namespace

namespace StarBank.Controllers
{
     // Verifica se o usuário está autenticado através do JWT
    [Route("v1")]
    [ApiController]
    public class SaldoController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public SaldoController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
    }
}
