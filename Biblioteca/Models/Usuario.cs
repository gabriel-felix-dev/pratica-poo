namespace Biblioteca.Models;

public class Usuario
{
    public Usuario(string nome, string email, string telefone)
    {
        Id = ++ContadorId;
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    public static int ContadorId = 0;
    public int Id { get; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
}
