using Biblioteca.Models;

namespace Biblioteca.Repositories;

public class LivroRepository
{
    private static readonly List<Livro> _livros = [];

    public static void AdicionarLivro(Livro livro) => _livros.Add(livro);
}
