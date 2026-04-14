using Biblioteca.Enums;

namespace Biblioteca.Models;

public class Livro
{
    public Livro(string titulo, string autor, int anoPublicacao)
    {
        Id = ++ContadorId;
        Titulo = titulo;
        Autor = autor;
        AnoPublicacao = anoPublicacao;
        StatusLivro = StatusLivroEnum.Disponivel;
    }

    public static int ContadorId = 0;
    public int Id { get; }
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public int AnoPublicacao { get; private set; }
    public StatusLivroEnum StatusLivro { get; private set; }

    public void AlteraStatus(StatusLivroEnum novoStatus) => StatusLivro = novoStatus;

    public string DeletaLivro()
    {
        if (StatusLivro.Equals(StatusLivroEnum.Reservado))
            return "\nNão foi possível excluir o livro, ele está reservado.";

        StatusLivro = StatusLivroEnum.Indisponivel;
        return $"\nStatus do livro {Titulo} foi alterado!";
    }

    public override string ToString() => $"Id: {Id} | Titulo: {Titulo} | Autor: {Autor} | Ano Publicação: {AnoPublicacao} | Status Livro: {StatusLivro}";
}
