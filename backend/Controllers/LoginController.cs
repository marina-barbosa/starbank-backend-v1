namespace StarBank.Controllers;

using Microsoft.AspNetCore.Mvc;
using StarPay.Domain.DTOs;
using StarPay.Infra.Services;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly TokenServices _tokenServices;

    public AuthController(UserService userService, TokenServices tokenServices)
    {
        _userService = userService;
        _tokenServices = tokenServices;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        if (string.IsNullOrEmpty(login.CpfCnpj) || string.IsNullOrEmpty(login.Password))
        {
            return BadRequest("CPF/CNPJ e senha precisam ser informados");
        }

        var user = await _userService.GetUserByLoginAsync(login.CpfCnpj, login.Password);
        if (user == null)
        {
            return BadRequest("CPF/CNPJ ou senha inválidos");
        }

        var token = _tokenServices.GenerateTokenJwt(user);

        return Ok(new { token });
    }
}