
using Microsoft.EntityFrameworkCore;

public interface IAutenticacaoService
{
    Task<Customer> AutenticarUsuario(string email, string senha);
}


// public class AutenticacaoService : IAutenticacaoService
// {
//     private readonly AppDbContext _context;

//     public AutenticacaoService(AppDbContext context)
//     {
//         _context = context;
//     }

//     public async Task<Usuario> AutenticarUsuario(string email, string senha)
//     {
//         var usuarioLogado = await _context.Usuarios.SingleOrDefaultAsync(usuario => usuario.Email == email);

//         if (usuarioLogado == null)
//         {
//             return null;
//         }

//         if (!BCrypt.Net.BCrypt.Verify(senha, usuarioLogado.SenhaLogin))
//         {
//             return null;
//         }

//         return usuarioLogado;
//     }


// }

