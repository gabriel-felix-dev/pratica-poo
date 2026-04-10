using Biblioteca.DTO;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.UI;

public static class Menu
{
    public static int MostrarMenu()
    {
        int opcaoUsuario;

        Console.WriteLine("1 - Cadastrar livro");
        Console.WriteLine("2 - Mostrar livros cadastrados");
        Console.WriteLine("0 - Sair");

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

    public static void ImprimeLivros(List<Livro> livros)
    {
        foreach (var item in livros)
            Console.WriteLine($"Id: {item.Id} | Livro: {item.Nome} | Autor: {item.Autor}");
    }

    public static EmprestimoDTO EmprestimoLivro()
    {
        DateTime dataEmprestimo = DateTime.Now;

        int idUsuario;

        Console.Write("Qual o id do usuário? ");

        while (!int.TryParse(Console.ReadLine(), out idUsuario))
            Console.WriteLine("Opçaõ inválida, digite novamente: ");
        
        

        return new EmprestimoDTO(usuario, livro, dataEmprestimo);
    }

}
