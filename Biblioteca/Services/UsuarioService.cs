using Biblioteca.Models;
using Biblioteca.Repositories;

namespace Biblioteca.Services;

public class UsuarioService
{

    private UsuarioRepository _usuarioRepository;

    public List<Usuario> PegaUsuario(int id)
    {
        int posicaoUsuario = _usuarioRepository.MostraUsuarios().IndexOf(id);
        
        return _usuarioRepository.
    }
}
