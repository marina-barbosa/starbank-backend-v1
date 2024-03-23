using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StarBank.Domain.DTOs;
using StarBank.Domain.Models;

namespace StarBank.Controllers;

[ApiController]
[Route("[users]")]
public class UsersController : ControllerBase
{

    private readonly UserManager<User>? _userManager;

    private readonly IMapper _mapper;

    public UsersController(IMapper imapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    private readonly IMapper _imapper;
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        _mapper.Map<User>(registerDto);
        var user = new User
        {
            UserName = registerDto.CpfCnpj
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();
    }
}