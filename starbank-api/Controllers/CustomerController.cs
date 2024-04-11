

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace starbank_api.Domain.Models;


[ApiController]
[Route("v1/customer")]
public class CustomerController : ControllerBase
{
    private readonly StarDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _appSettings;




    public CustomerController(StarDbContext context, IMapper mapper, IConfiguration appSettings)
    {
        _context = context;
        _mapper = mapper;
        _appSettings = appSettings;
    }





    [HttpGet("{id}")]
    // [Authorize]
    public async Task<ActionResult<CustomerResponseDto>> GetCustomerById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        CustomerResponseDto customerResponse = _mapper.Map<CustomerResponseDto>(customer);
        return Ok(customerResponse);
    }

    [HttpGet("email/{email}")]
    // [Authorize]
    public async Task<ActionResult<CustomerResponseDto>> GetCustomerByEmail(string email)
    {
        var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Email == email);

        if (customer == null)
        {
            return NotFound();
        }
        CustomerResponseDto customerResponse = _mapper.Map<CustomerResponseDto>(customer);
        return Ok(customerResponse);
    }

}
