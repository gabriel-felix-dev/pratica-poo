using Biblioteca.DTO;
using Biblioteca.Models;
using Biblioteca.Repositories;
using Biblioteca.Services;
using Biblioteca.UI;

LivroRepository livroRepository = new LivroRepository();
LivroService livroService = new LivroService(livroRepository);

Usuario usuario = new Usuario("João");

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
            EmprestimoDTO emprestimoDTO = Menu.EmprestimoLivro();
            Menu.ImprimeLivros(livroService.ImprimeLivros());
            break;
        default:
            Console.WriteLine("Programa encerrado");
            break;
    }

    continue;
}