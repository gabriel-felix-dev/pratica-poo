namespace Biblioteca.Models;

public class Usuario
{
    public Usuario(string nome)
    {
        Id = ++ContadorId;
        Nome = nome;
    }

    public static int ContadorId = 0;
    public int Id { get; }
    public string Nome { get; private set; }
}
