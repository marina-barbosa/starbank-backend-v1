namespace StarPay.Infra.Services;


public class TokenServices
{
    private Iconfiguration configuration;

    public TokenServices(Iconfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GenerateTokenJwt(User user)
    {
        {
            Claim[] claims = new Claim[]
            new("user", user.CpfCnpj)
            new("password", user.Password)
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