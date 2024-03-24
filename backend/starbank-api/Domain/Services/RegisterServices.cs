
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using starbank_api.Domain.Models;

namespace starbank_api.Domain.Services;

public class RegisterServices : Exception
{
    private readonly IConfiguration _appSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly StarDbContext _context;

    public RegisterServices(IConfiguration appSettings, IHttpContextAccessor httpContextAccessor, IMapper mapper, StarDbContext context)
    {
        _appSettings = appSettings;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
        _context = context;
    }



    public async Task<bool> RegisterCustomer(CustomerRequestDto customerRequest)
    {
        customerRequest.LoginPassword = BCrypt.Net.BCrypt.HashPassword(customerRequest.LoginPassword);

        Customer newCustomer = _mapper.Map<Customer>(customerRequest);

        newCustomer.AcceptedTerm = true;
        newCustomer.ActiveAccount = true;
        newCustomer.CreatedAt = DateTime.Now;
        newCustomer.UpdatedAt = DateTime.Now;

        try
        {
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateException ex)
        {
            throw new Exception($"Erro interno do servidor: {ex.Message}");
        }
    }
    // public async void RegisterPj(PjRequestDto pjRequest)
    // {
    // }
    // public async void RegisterPf(PfRequestDto pfRequest)
    // {
    // }
    // public async void RegisterAddress(AddressRequestDto addressRequest)
    // {
    // }
    // public async void RegisterAccount(AccountRequestDto accountRequest)
    // {
    // }
    // public async void RegisterCard(CardRequestDto cardRequest)
    // {
    // }














}

