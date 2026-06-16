namespace MedConsulta.Helpers;

public static class Helper
{
    public static int ValidadorMenu()
    {
        int opcao;

        while (!int.TryParse(Console.ReadLine().Trim(), out opcao) || opcao < 0 || opcao > 25)
            Console.Write("\nOpção inválida, digite novamente: ");

        return opcao;
    }

    public static string ValidadorTexto()
    {
        string texto = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(texto))
        {
            Console.Write("\nInformação inválida, digite novamente :");
            texto = Console.ReadLine().Trim();
        }

        return texto;
    }

    public static string ValidadorCrm()
    {
        string texto = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(texto) || texto.Length > 7 || texto.Length < 4 || !texto.All(char.IsDigit))
        {
            Console.Write("\nCrm informado inválido, digite novamente (4 a 7 dígitos): ");
            texto = Console.ReadLine().Trim();
        }

        return $"CRM{texto}";
    }

    public static bool ValidadorListaVazia<T>(List<T> lista, string texto)
    {
        if (lista.Count == 0)
        {
            Console.WriteLine($"\nNenhum item cadastrado na lista de {texto}.");
            ReduzirTempo();
            return true;
        }
        return false;
    }

    public static bool ValidadorObjetoNulo(object objeto)
    {
        if (objeto == null)
            return true;

        return false;
    }

    public static Guid ValidadorGuid()
    {
        Guid guid;

        while (!Guid.TryParse(Console.ReadLine().Trim(), out guid))
            Console.Write("\nId inválido, digite novamente: ");

        return guid;
    }

    public static string ValidadorNumeroConsulta()
    {
        string texto = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(texto) || texto.Length < 4 || !texto.All(char.IsDigit))
        {
            Console.Write("\nCódigo informado inválido, digite novamente (4 dígitos - Exemplo:  0512): ");
            texto = Console.ReadLine().Trim();
        }

        return $"CRM{texto}";
    }

    static void ReduzirTempo() => Thread.Sleep(1500);
}
