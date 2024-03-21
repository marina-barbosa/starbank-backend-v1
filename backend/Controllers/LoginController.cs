[HttpPost("login")]
public IActionResult Login([FromBody] Login login)
{
    if (string.IsNullOrEmpty(login.CpfCnpj) || string.IsNullOrEmpty(login.Password))
    {
        return BadRequest("CPF/CNPJ e senha precisam ser informados");
    }

    var isCpf = login.CpfCnpj.Length == 11;
    var isCnpj = login.CpfCnpj.Length == 14;

    if (!isCpf && !isCnpj)
    {
        return BadRequest("CPF/CNPJ inválido");
    }

    if (isCpf)
    {
        if (!IsCpf(login.CpfCnpj))
        {
            return BadRequest("CPF inválido");
        }
    }
    else
    {
        if (!IsCnpj(login.CpfCnpj))
        {
            return BadRequest("CNPJ inválido");
        }
    }

    var user = _context.Customers.SingleOrDefault(x => (isCpf && x.CpfCnpj == login.CpfCnpj) || (isCnpj && x.CpfCnpj == login.CpfCnpj && x.Password == login.Password));
    if (user == null)
    {
        return BadRequest("CPF/CNPJ ou senha inválido");
    }

    var token = GenerateTokenJwt(user);

    return Ok(new { token });
}
