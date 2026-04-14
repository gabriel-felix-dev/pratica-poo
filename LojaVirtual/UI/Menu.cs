using LojaVirtual.Helpers;
using LojaVirtual.Models;
using LojaVirtual.Repositories;

namespace LojaVirtual.UI;

public static class Menu
{
    public static int MostrarMenu()
    {
        int opcaoDigitada;

        Console.WriteLine("\nEscolha uma opção: \n");

        Console.WriteLine("1 - Cadastrar Categoria");
        Console.WriteLine("2 - Verificar Categorias");
        Console.WriteLine("0 - Sair");

        Console.Write("\nDigte a opção escolhida: ");

        string opcaoSolicitada = Console.ReadLine();

        while (!int.TryParse(opcaoSolicitada, out opcaoDigitada) || opcaoDigitada < 0 || opcaoDigitada > 2)
        {
            Console.Write($"\nOpção inválida, digite novamente: ");
            opcaoSolicitada = Console.ReadLine();
        }

        return opcaoDigitada;
    }

    public static void CadastrarCategoria()
    {
        string nomeCategoria;

        Console.Write($"Digite o nome da Categoria: ");
        nomeCategoria = Console.ReadLine().Trim();

        Helper.ValidaNomeCategoria(nomeCategoria);

        Categoria categoria = new Categoria(nomeCategoria);

        CategoriaRepository.AdicionaCategoriaNaLista(categoria);
    }

    public static void VerificaCategoriasCadastradas()
    {
        foreach (var item in CategoriaRepository.RetornaLista())
            Console.WriteLine(item);
    }

}
