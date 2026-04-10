using Biblioteca.Enum;
namespace Biblioteca.Models;

public class Livro
{
    public Livro(string nome, string autor)
    {
        Nome = nome;
        Autor = autor;
        StatusLivro = StatusLivroEnum.Disponivel;
    }

    public string Nome { get; }
    public string Autor { get; }
    public StatusLivroEnum StatusLivro { get; private set; }

}
