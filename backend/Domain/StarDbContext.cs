using StarBank.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StarBank.Domain
{
    public class StarDbContext : IdentityDbContext<User>
    {
       
    }
}