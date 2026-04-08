namespace biblioteca_leia_mais.Models;

public class Emprestimo
{
    public Emprestimo(Usuario usuario, Livro livro)
    {
        Id = ++ContadorId;
        DataReserva = DateTime.Now;
        Usuario = usuario;
        Livro = livro;
    }

    public static int ContadorId = 0;
    public int Id { get; }
    public Usuario Usuario { get; private set; }
    public Livro Livro { get; private set; }
    public DateTime DataReserva { get; private set; }

    public static void DevolverLivro(int diasComLivro, int IdLivro)
    {
        
    }
}
