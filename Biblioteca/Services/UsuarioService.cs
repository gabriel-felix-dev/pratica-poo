using biblioteca.DTO;
using Biblioteca.Models;
using Biblioteca.Repositories;

namespace Biblioteca.Services;

public class UsuarioService
{
    public UsuarioService(UsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    private UsuarioRepository _usuarioRepository;

    public void CadastrarUsuario(UsuarioDTO dto)
    {
        Usuario usuario = new Usuario(dto.NomeUsuario, dto.EmailUsuario, dto.TelefoneUsuario);

        _usuarioRepository.AdicionarUsuario(usuario);
    }
}
