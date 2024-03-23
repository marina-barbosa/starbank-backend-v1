namespace StarPay.Infra.Services;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


public class TokenServices
{
    private IConfiguration configuration;

    public TokenServices(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateTokenJwt(User user)
    {
        {
            Claim[] claims = new Claim[];
            new("user", user.CpfCnpj);
            new("password", user.Password);
        };

        configuration["SymmetricSecurityKey"](Encoding.UTF8.GetBytes(configuration["yekkeygennkay"]));

        var loginCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddDays(5),
            sigmingCredentials: loginCredentials,
            claims: claims);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}