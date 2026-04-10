using Biblioteca.Enum;
namespace Biblioteca.Models;

public class Livro
{
    public Livro(string nome, string autor)
    {
        Id = ++ContadorId;
        Nome = nome;
        Autor = autor;
        StatusLivro = StatusLivroEnum.Disponivel;
    }

    private static int ContadorId = 0;
    public int Id { get; }
    public string Nome { get; }
    public string Autor { get; }
    public StatusLivroEnum StatusLivro { get; private set; }

}
