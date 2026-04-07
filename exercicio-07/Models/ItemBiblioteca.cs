namespace exercicio_07.Models;

public class ItemBiblioteca
{
    public string Titulo { get; private set; }
    public int AnoPublicacao { get; private set; }
    public bool Emprestado { get; }
}
