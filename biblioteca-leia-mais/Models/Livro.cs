namespace biblioteca_leia_mais.Models;

public class Livro
{
    public Livro(string titulo)
    {
        Id = ++ContadorId;
        Titulo = titulo;
    }

    public static int ContadorId = 0;
    public int Id { get; }
    public String Titulo { get; private set; }
    public bool StatusLivro { get; private set; }

    public void AlteraStausLivro()
    {
        StatusLivro = true;
    }

    public override string ToString()
    {
        return $"Id: {Id} | Titulo: {Titulo} | Status: {(StatusLivro ? "Reservado" : "Disponível")}";
    }

}
