using Biblioteca.Models;

namespace Biblioteca.Repositories;

public class UsuarioRepository
{
    private readonly List<Usuario> _usuarios = [];

    // A lista será alterada somente por métodos

    // Repository só tem a função de guardar listas e ter o métodos alterar a lista. A Repository funciona como o banco de dados por meio das listas

    public void AdicionarUsuario(Usuario usuario)
       => _usuarios.Add(usuario);


    public List<Usuario> MostraUsuarios()
    {
        return _usuarios;
    }
}
