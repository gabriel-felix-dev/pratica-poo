using Biblioteca.Models;

namespace Biblioteca.Repositories;

public class UsuarioRepository
{
    private static readonly List<Usuario> _usuarios = [];

    public static void AdicioanrUsuario(Usuario usuario) => _usuarios.Add(usuario);
}
