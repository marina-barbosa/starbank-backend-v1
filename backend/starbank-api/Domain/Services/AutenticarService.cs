using Microsoft.EntityFrameworkCore;
using starbank_api.Domain.Models;

namespace starbank_api.Domain.Services;

public interface IAutenticacaoService
{
    Task<Customer> AutenticarCustomer(string email, string password);
}

public class AutenticacaoService : IAutenticacaoService
{
    private readonly StarDbContext _context;

    public AutenticacaoService(StarDbContext context)
    {
        _context = context;
    }

    public async Task<Customer> AutenticarCustomer(string email, string password)
    {
        var customerLoggedIn = await _context.Customers.SingleOrDefaultAsync(customer => customer.Email == email);

        if (customerLoggedIn == null)
        {
            return null;
        }

        if (!BCrypt.Net.BCrypt.Verify(password, customerLoggedIn.LoginPassword))
        {
            return null;
        }

        return customerLoggedIn;
    }


}

