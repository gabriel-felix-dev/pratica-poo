namespace LojaVirtual.Helpers;

public static class Helper
{
    public static void ValidaNomeCategoria(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("O nome da categoria deve ser preenchido");
            return;
        }
    }
}
