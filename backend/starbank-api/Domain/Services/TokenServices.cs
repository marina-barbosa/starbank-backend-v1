using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using starbank_api.Domain.Models;

namespace starbank_api.Domain.Services;

public class TokenServices
{
    private readonly IConfiguration _appSettings;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TokenServices(IConfiguration appSettings, IHttpContextAccessor httpContextAccessor)
    {
        _appSettings = appSettings;
        _httpContextAccessor = httpContextAccessor;
    }



    public string GenerateToken(Customer customer)
    {
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var keyString = _appSettings["Jwt:Key"];
            if (string.IsNullOrEmpty(keyString))
            {
                throw new ArgumentNullException("Jwt:Key", "A chave de assinatura JWT não pode ser nula ou vazia.");
            }
            var key = Encoding.ASCII.GetBytes(keyString);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, customer.Name),
            new Claim(JwtRegisteredClaimNames.Email, customer.Email),
            //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, customer.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.NameId, customer.Id.ToString())
        }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _appSettings["Jwt:Issuer"],
                Audience = _appSettings["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public string ExtractEmailToken()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var token = httpContext?.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
        // var token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        var tokenHandler = new JwtSecurityTokenHandler();
        var keyString = _appSettings["Jwt:Key"];
        if (string.IsNullOrEmpty(keyString))
        {
            throw new ArgumentNullException("Jwt:Key", "A chave de assinatura JWT não pode ser nula ou vazia.");
        }
        var key = Encoding.ASCII.GetBytes(keyString);
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
    public string ExtractIdToken()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var token = httpContext?.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
        // var token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        var tokenHandler = new JwtSecurityTokenHandler();
        var keyString = _appSettings["Jwt:Key"];
        if (string.IsNullOrEmpty(keyString))
        {
            throw new ArgumentNullException("Jwt:Key", "A chave de assinatura JWT não pode ser nula ou vazia.");
        }
        var key = Encoding.ASCII.GetBytes(keyString);
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
            return jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.NameId).Value;
        }
        catch
        {
            // Retorna null se a validação falhar
            return "Falha na extração do token.";
        }
    }
}





