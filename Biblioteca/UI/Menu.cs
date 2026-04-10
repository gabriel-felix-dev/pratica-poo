using Biblioteca.DTO;
using Biblioteca.Models;

namespace Biblioteca.UI;

public static class Menu
{
    public static int MostrarMenu()
    {
        int opcaoUsuario;

        Console.WriteLine("1 - Cadastrar livro");
        Console.WriteLine("2 - Sair");

        while (!int.TryParse(Console.ReadLine(), out opcaoUsuario) || opcaoUsuario < 1 || opcaoUsuario > 2)
            Console.WriteLine("Opçaõ inválida, digite novamente: ");

        return opcaoUsuario;
    }

    public static LivroDTO CadastrarLivro()
    {
        string nomeLivro;
        string nomeAutor;

        Console.WriteLine("Digite o nome do livro: ");
        nomeLivro = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(nomeLivro))
        {
            Console.WriteLine("O nome do livros esta nulo, digite novamente: ");
            nomeLivro = Console.ReadLine();
        }

        Console.WriteLine("Digite o nome do autor: ");
        nomeAutor = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(nomeAutor))
        {
            Console.WriteLine("O nome do autor esta nulo, digite novamente: ");
            nomeAutor = Console.ReadLine();
        }

        return new LivroDTO(nomeLivro, nomeAutor);
    }
}
