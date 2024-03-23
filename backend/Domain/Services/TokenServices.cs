using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace StarPay.Infra.Services;

public class TokenServices
{
    private readonly IConfiguration _appSettings;

    public TokenServices(IConfiguration appsettings)
    {
        _appSettings = appsettings;
    }

    public string ExtractIdToken(string token)
    {


        return "" + token;
    }


    // private string CreateToken(Customer usuario)
    // {
    //     {
    //         var tokenHandler = new JwtSecurityTokenHandler();
    //         var key = Encoding.ASCII.GetBytes(_appSettings["Jwt:Key"]);
    //         var tokenDescriptor = new SecurityTokenDescriptor
    //         {
    //             Subject = new ClaimsIdentity(new[]
    //             {
    //         new Claim(JwtRegisteredClaimNames.Sub, usuario.Name),
    //         new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
    //         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //     }),
    //             Expires = DateTime.UtcNow.AddHours(2),
    //             Issuer = _appSettings["Jwt:Issuer"],
    //             Audience = _appSettings["Jwt:Audience"],
    //             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
    //         };
    //         var token = tokenHandler.CreateToken(tokenDescriptor);
    //         return tokenHandler.WriteToken(token);
    //     }
    // }

    // public string GenerateTokenJwt(Customer customer)
    // {
    //     {
    //         Claim[] claims = new Claim[];
    //         new("customer", customer.CpfCnpj);
    //         new("password", user.Password);
    //     };

    //     _appsettings["SymmetricSecurityKey"](Encoding.UTF8.GetBytes(_appsettings["yekkeygennkay"]));

    //     var loginCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //     var token = new JwtSecurityToken(
    //         expires: DateTime.Now.AddDays(5),
    //         sigmingCredentials: loginCredentials,
    //         claims: claims);

    //     return new JwtSecurityTokenHandler().WriteToken(token);
    // }
}
