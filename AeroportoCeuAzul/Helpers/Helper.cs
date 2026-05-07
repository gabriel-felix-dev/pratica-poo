namespace AeroportoCeuAzul.Helpers;

public static class Helper
{
    public static int ValidaNumeroInteiro()
    {
        int numero;

        while (!int.TryParse(Console.ReadLine(), out numero))
            Console.Write("\nNúmero inválido, digite novamente: ");

        return numero;
    }

    public static void ValidaTexto(string texto)
    {
        while (string.IsNullOrWhiteSpace(texto))
        {
            Console.Write("\nTexto inválido, digite novamente: ");
            texto = Console.ReadLine();
        }
    }
}
