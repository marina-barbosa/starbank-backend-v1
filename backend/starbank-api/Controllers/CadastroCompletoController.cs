using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using starbank_api.Domain.Services;

namespace starbank_api.Domain.Models;

[ApiController]
[Route("v1/account")]

public class CadastroCompletoController : ControllerBase
{
    private readonly StarDbContext _context;
    private readonly IMapper _mapper;
    private readonly TokenServices _tokenServices;
    private readonly RegisterServices _registerServices;


    public CadastroCompletoController(StarDbContext context, IMapper mapper, TokenServices tokenServices, RegisterServices registerServices)
    {
        _context = context;
        _mapper = mapper;
        _tokenServices = tokenServices;
        _registerServices = registerServices;
    }


    public class RegistroCompletoModel
    {
        public CustomerRequestDto CustomerRequest { get; set; }
        public ClientType ClientType { get; set; }
        public LegalEntity LegalEntity { get; set; }
        public NaturalPerson NaturalPerson { get; set; }
        public Address Address { get; set; }
        public Account Account { get; set; }
        public Card Card { get; set; }
    }

    [HttpPost("registrocompleto")]
    public async Task<ActionResult<bool>> RegistroCompleto([FromBody] RegistroCompletoModel registros)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _registerServices.RegisterCustomer(registros.CustomerRequest);

        if (registros.ClientType == 0)
        {
            return Ok(registros.ClientType);
        }
        else
        {
            return Ok("outro" + registros.ClientType);
        }

        // if enum

        // pf ou pj 0 ou 1
        // address
        // conta
        // cartao



    }
}