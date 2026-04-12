using biblioteca.DTO;
using Biblioteca.DTO;
using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.UI;

public static class Menu
{
    public static int MostrarMenu()
    {
        int opcaoUsuario;

        Console.WriteLine("\n#### Biblioteca Leia Mais ####");
        Console.WriteLine("\n1 - Cadastrar livro");
        Console.WriteLine("2 - Mostrar livros cadastrados");
        Console.WriteLine("3 - Cadastrar novo usuario");
        Console.WriteLine("4 - Realizar emprestimo");
        Console.WriteLine("0 - Sair");
        Console.Write("\nDigite uma opção para seguir: ");

        while (!int.TryParse(Console.ReadLine(), out opcaoUsuario) || opcaoUsuario < 0 || opcaoUsuario > 4)
            Console.Write("\nOpçaõ inválida, digite novamente: ");

        return opcaoUsuario;
    }

    public static LivroDTO CadastrarLivro()
    {
        string nomeLivro;
        string nomeAutor;

        Console.Write("\nDigite o nome do livro: ");
        nomeLivro = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(nomeLivro))
        {
            Console.Write("\nO nome do livros esta nulo, digite novamente: ");
            nomeLivro = Console.ReadLine();
        }

        Console.Write("\nDigite o nome do autor: ");
        nomeAutor = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(nomeAutor))
        {
            Console.Write("\nO nome do autor esta nulo, digite novamente: ");
            nomeAutor = Console.ReadLine();
        }

        Console.WriteLine("\nLivro cadastrado com sucesso!");
        Thread.Sleep(1000);

        return new LivroDTO(nomeLivro, nomeAutor);
    }

    public static void ImprimeLivros(List<Livro> livros)
    {
        Console.WriteLine("\nLista de livros cadastrados: \n");

        foreach (var item in livros)
            Console.WriteLine($"Id: {item.Id} | Livro: {item.Nome} | Autor: {item.Autor}");

        Thread.Sleep(1000);
    }

    public static UsuarioDTO CadadastrarUsuario()
    {
        string nomeUsuario;
        string emailUsuario;
        string telefoneUsuario;

        Console.WriteLine("Digite o nome do novo usuario: ");
        nomeUsuario = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(nomeUsuario))
        {
            Console.WriteLine("O nome do usuario deve ser preenchido, digite novamente: ");
            nomeUsuario = Console.ReadLine();
        }

        Console.WriteLine("Digite o email do usuario: ");
        emailUsuario = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(emailUsuario))
        {
            Console.WriteLine("O email do usuario deve ser preenchido, digite novamente: ");
            emailUsuario = Console.ReadLine();
        }

        Console.WriteLine("Digite o telefone do usuario: ");
        telefoneUsuario = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(telefoneUsuario))
        {
            Console.WriteLine("O telefone do usuario deve ser preenchido, digite novamente: ");
            telefoneUsuario = Console.ReadLine();
        }

        return new UsuarioDTO(nomeUsuario, emailUsuario, telefoneUsuario);
    }

    public static void EncerrarSistema()
    {
        Console.WriteLine("\nPrograma encerrado\n");
        Thread.Sleep(1000);
        Environment.Exit(0);
    }

    // public static EmprestimoDTO EmprestimoLivro()
    // {
    //     DateTime dataEmprestimo = DateTime.Now;

    //     int idUsuario;

    //     Console.Write("Qual o id do usuário? ");

    //     while (!int.TryParse(Console.ReadLine(), out idUsuario))
    //         Console.WriteLine("Opçaõ inválida, digite novamente: ");



    //     return new EmprestimoDTO(usuario, livro, dataEmprestimo);
    // }

}
