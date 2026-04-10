using Biblioteca.Models;

namespace Biblioteca.Repositories;

public class LivroRepository
{
    private readonly List<Livro> _livros = [];

    // A lista será alterada somente por métodos
    
    // Repository só tem a função de guardar listas e ter o métodos alterar a lista. A Repository funciona como o banco de dados por meio das listas

    public void AdicionarLivro(Livro livro)
    {
        _livros.Add(livro);
    }
}
