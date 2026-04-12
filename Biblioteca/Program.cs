using biblioteca.DTO;
using Biblioteca.DTO;
using Biblioteca.Repositories;
using Biblioteca.Services;
using Biblioteca.UI;

LivroRepository livroRepository = new LivroRepository();
LivroService livroService = new LivroService(livroRepository);

UsuarioRepository usuarioRepository = new UsuarioRepository();
UsuarioService usuarioService = new UsuarioService(usuarioRepository);

while (true)
{
    int opcaoMenu = Menu.MostrarMenu();


    switch (opcaoMenu)
    {
        case 1:
            LivroDTO livro = Menu.CadastrarLivro();
            livroService.CadastrarLivro(livro);
            break;
        case 2:
            Menu.ImprimeLivros(livroService.ImprimeLivros());
            break;
        case 3:
            UsuarioDTO usuario = Menu.CadadastrarUsuario();
            usuarioService.CadastrarUsuario(usuario);
            break;
        case 4:
            // EmprestimoDTO emprestimoDTO = Menu.EmprestimoLivro();
            // Menu.ImprimeLivros(livroService.ImprimeLivros());
            break;
        default:
            Menu.EncerrarSistema();
            break;
    }

    continue;
}