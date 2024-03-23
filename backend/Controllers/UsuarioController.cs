using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;
using dotnet_banco_digital.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace dotnet_banco_digital.Controllers;

public class UsuarioLogadoResponse
{
    public int Id { get; set; }
    public string Email { get; set; }
}


[ApiController]
[Route("v1/usuario")]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _appSettings;




    public UsuariosController(AppDbContext context, IMapper mapper, IConfiguration appSettings)
    {
        _context = context;
        _mapper = mapper;
        _appSettings = appSettings;
    }




    // [HttpPost("cadastro")]
    // public async Task<ActionResult<Usuario>> CadastraUsuario(UsuarioRequestDto usuarioRequest)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }

    //     usuarioRequest.SenhaLogin = BCrypt.Net.BCrypt.HashPassword(usuarioRequest.SenhaLogin);

    //     Usuario novoUsuario = _mapper.Map<Usuario>(usuarioRequest);

    //     try
    //     {
    //         _context.Usuarios.Add(novoUsuario);
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateException ex) when ((ex.InnerException as PostgresException)?.SqlState == "23505")
    //     {
    //         var errorMessage = ex.InnerException.Message;
    //         if (errorMessage.Contains("IX_Usuarios_Email"))
    //         {
    //             return Conflict("Email já cadastrado.");
    //         }

    //         if (errorMessage.Contains("IX_Usuarios_Cpf"))
    //         {
    //             return Conflict("CPF já cadastrado.");
    //         }
    //     }
    //     catch (DbUpdateException ex)
    //     {

    //         return StatusCode(500, "Erro interno do servidor.");
    //     }

    //     var usuarioResponseDto = _mapper.Map<UsuarioResponseDto>(novoUsuario);
    //     return CreatedAtAction("GetUsuario", new { id = novoUsuario.Id }, usuarioResponseDto);

    //     //return CreatedAtAction("GetUsuario", new { id = novoUsuario.Id }, novoUsuario);
    // }





    [HttpGet("logado")]
    [Authorize]
    public string? GetUsuarioLogado()
    {
        var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        return ExtractEmailToken(token);
    }

    [NonAction]
    public string ExtractEmailToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings["Jwt:Key"]);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _appSettings["Jwt:Issuer"],
                ValidAudience = _appSettings["Jwt:Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Email).Value;
        }
        catch
        {
            // Retorna null se a validação falhar
            return "Falha na extração do token.";
        }
    }



    // [HttpGet("{id}")]
    // [Authorize]
    // public async Task<ActionResult<UsuarioResponseDto>> GetUsuario(int id)
    // {
    //     var usuario = await _context.Usuarios.FindAsync(id);
    //     if (usuario == null)
    //     {
    //         return NotFound();
    //     }
    //     UsuarioResponseDto usuarioResponse = _mapper.Map<UsuarioResponseDto>(usuario);
    //     return usuarioResponse;
    // }

    // [HttpGet("{id}/saldo")]
    // public async Task<IActionResult> ConsultarSaldo(int id)
    // {
    //     var conta = await _context.Contas.FindAsync(id);

    //     if (conta == null)
    //     {
    //         return NotFound("Conta não encontrada.");
    //     }

    //     return Ok(conta.Saldo);
    // }

    // [HttpPost("{id}/deposito")]
    // public async Task<IActionResult> Deposito(int id, [FromBody] decimal valor)
    // {
    //     var conta = await _context.Contas.FindAsync(id);

    //     if (conta == null)
    //     {
    //         return NotFound("Conta não encontrada.");
    //     }

    //     conta.Saldo += valor;
    //     await _context.SaveChangesAsync();

    //     return Ok(conta.Saldo);
    // }

    // [HttpPost("{id}/saque")]
    // public async Task<IActionResult> Saque(int id, [FromBody] decimal valor)
    // {
    //     var conta = await _context.Contas.FindAsync(id);

    //     if (conta == null)
    //     {
    //         return NotFound("Conta não encontrada.");
    //     }

    //     if (conta.Saldo < valor)
    //     {
    //         return BadRequest("Saldo insuficiente.");
    //     }

    //     conta.Saldo -= valor;
    //     await _context.SaveChangesAsync();

    //     return Ok(conta.Saldo);
    // }



    // [HttpGet("saldo/{id}")]
    // public async Task<IActionResult> ConsultarSaldo(int id)
    // {
    //     var usuario = await _context.Usuarios.FindAsync(id);
    //     if (usuario == null)
    //     {
    //         return NotFound("Usuário não encontrado.");
    //     }

    //     return Ok(new { saldo = usuario.Saldo });
    // }


    // [HttpPatch("deposito/{id}")]
    // public async Task<IActionResult> RealizarDeposito(int id, [FromBody] decimal valorDeposito)
    // {
    //     var usuario = await _context.Usuarios.FindAsync(id);
    //     if (usuario == null)
    //     {
    //         return NotFound("Usuário não encontrado.");
    //     }

    //     usuario.Saldo += valorDeposito;

    //     _context.Usuarios.Update(usuario);
    //     await _context.SaveChangesAsync();

    //     return Ok(new { message = "Depósito realizado com sucesso.", novoSaldo = usuario.Saldo });
    // }


    // [HttpPatch("saque/{id}")]
    // public async Task<IActionResult> RealizarSaque(int id, [FromBody] decimal valorSaque)
    // {
    //     var usuario = await _context.Usuarios.FindAsync(id);
    //     if (usuario == null)
    //     {
    //         return NotFound("Usuário não encontrado.");
    //     }

    //     if (usuario.Saldo < valorSaque)
    //     {
    //         return BadRequest("Saldo insuficiente para realizar o saque.");
    //     }

    //     usuario.Saldo -= valorSaque;

    //     _context.Usuarios.Update(usuario);
    //     await _context.SaveChangesAsync();

    //     return Ok(new { message = "Saque realizado com sucesso.", novoSaldo = usuario.Saldo });
    // }


    // [HttpGet("usuario/{usuarioId}/transacao/{transacaoId}")]
    // public async Task<ActionResult<Transacao>> GetByIdTransacao(int usuarioId, int transacaoId)
    // {
    //     var transacao = await _context.Transacoes
    //         .Where(t => (t.UsuarioOrigemId == usuarioId || t.UsuarioDestinoId == usuarioId) && t.Id == transacaoId)
    //         .FirstOrDefaultAsync();

    //     if (transacao == null)
    //     {
    //         return NotFound("Transação não encontrada para o usuário especificado.");
    //     }

    //     return transacao;
    // }

    // [HttpGet("transacoes/{id}")]
    // public async Task<ActionResult<IEnumerable<Transacao>>> GetAllTransacoes(int id)
    // {
    //     var transacoes = await _context.Transacoes
    //         .Where(t => t.UsuarioOrigemId == id || t.UsuarioDestinoId == id)
    //         .ToListAsync();

    //     if (!transacoes.Any())
    //     {
    //         return NotFound("Nenhuma transação encontrada para o usuário especificado.");
    //     }

    //     return transacoes;
    // }


    // [HttpPost("pf/cadastro")]
    // public async Task<IActionResult> CadastrarPessoaFisica([FromBody] PessoaFisica pessoaFisica)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }

    //     try
    //     {
    //         _context.PessoasFisicas.Add(pessoaFisica);
    //         await _context.SaveChangesAsync();
    //         return Ok(pessoaFisica);
    //     }
    //     catch (DbUpdateException)
    //     {
    //         return BadRequest("Não foi possível salvar a Pessoa Física.");
    //     }
    // }


    // [HttpPost("pj/cadastro")]
    // public async Task<IActionResult> CadastrarPessoaJuridica([FromBody] PessoaJuridica pessoaJuridica)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }

    //     try
    //     {
    //         _context.PessoasJuridicas.Add(pessoaJuridica);
    //         await _context.SaveChangesAsync();
    //         return Ok(pessoaJuridica);
    //     }
    //     catch (DbUpdateException)
    //     {
    //         return BadRequest("Não foi possível salvar a Pessoa Jurídica.");
    //     }
    // }

    // [HttpPost("conta")]
    // public async Task<IActionResult> CadastrarConta([FromBody] Conta conta)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }

    //     try
    //     {
    //         _context.Contas.Add(conta);
    //         await _context.SaveChangesAsync();
    //         return Ok(conta);
    //     }
    //     catch (DbUpdateException)
    //     {
    //         return BadRequest("Não foi possível salvar a Conta.");
    //     }
    // }

    // [HttpPost("cartao")]
    // public async Task<IActionResult> CadastrarCartao([FromBody] Cartao cartao)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return BadRequest(ModelState);
    //     }

    //     try
    //     {
    //         _context.Cartoes.Add(cartao);
    //         await _context.SaveChangesAsync();
    //         return Ok(cartao);
    //     }
    //     catch (DbUpdateException)
    //     {
    //         return BadRequest("Não foi possível salvar o Cartão.");
    //     }
    // }


}
