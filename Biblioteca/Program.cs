using Biblioteca.DTO;
using Biblioteca.Repositories;
using Biblioteca.Services;
using Biblioteca.UI;

LivroRepository livroRepository = new LivroRepository();
LivroService livroService = new LivroService(livroRepository);

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

            break;
        default:
            break;
    }
}