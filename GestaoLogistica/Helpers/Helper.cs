namespace GestaoLogistica.Helpers;

public static class Helper
{
    public static string ValidadorTexto()
    {
        string texto = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(texto))
        {
            Console.Write("Informação inválida, digite novamente: ");
            texto = Console.ReadLine().Trim();
        }

        return texto;
    }

    public static string ValidadorEmail()
    {
        string email = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.') || email.StartsWith('@') || email.LastIndexOf('.') == email.Length - 1 || !email.Contains(".com"))
        {
            Console.Write("Email inválido, digite novamente: ");
            email = Console.ReadLine().Trim();
        }

        return email;
    }

    public static string ValidadorTelefone()
    {
        string telefone = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(telefone) || telefone.Length != 11 || !telefone.All(char.IsDigit) || !telefone.Substring(2, 1).Equals("9"))
        {
            Console.Write("Número de telefone inválido, digite novamente (apenas números, 11 dígitos): ");
            telefone = Console.ReadLine().Trim();
        }

        return telefone;
    }

    public static string ValidadorCpf()
    {
        string cpf = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            Console.Write("CPF inválido, digite novamente (apenas números, 11 dígitos): ");
            cpf = Console.ReadLine().Trim();
        }

        return cpf;
    }

    public static bool ValidaQuantidadeLista<T>(List<T> lista, string texto)
    {
        if (lista.Count == 0)
        {
            Console.Write($"\nNenhum item cadastrado na lista de {texto}. \n");
            return true;
        }

        return false;
    }

    public static bool ValidadorDatas(DateTime primeriraData, DateTime segundaData)
    {
        while (primeriraData >= segundaData)
        {
            Console.Write("A primeira data é maior ou igual à segunda data.\n");

            return true;
        }

        return false;
    }

    public static int ValidadorOpcaoMenu()
    {
        int opcaoMenu;

        while (!int.TryParse(Console.ReadLine().Trim(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > 4)
            Console.Write("Opção inválida, digite novamente: ");

        return opcaoMenu;
    }

    public static int ValidadorNumeroInterio()
    {
        int numeroInteiro;

        while (!int.TryParse(Console.ReadLine().Trim(), out numeroInteiro) || numeroInteiro < 0)
            Console.Write("Número inválido, digite novamente: ");

        return numeroInteiro;
    }

    public static double ValidadorDouble()
    {
        double numero;

        while (!double.TryParse(Console.ReadLine().Trim(), out numero) || numero < 0)
            Console.Write("Número inválido, digite novamente: ");

        return numero;
    }

    public static decimal ValidadorDecimal()
    {
        decimal numeroDecimal;

        while (!decimal.TryParse(Console.ReadLine().Trim(), out numeroDecimal) || numeroDecimal < 0)
            Console.Write("Número inválido, digite novamente: ");

        return numeroDecimal;
    }

    public static Guid ValidadorGuid()
    {
        Guid identificadorGuid;

        while (!Guid.TryParse(Console.ReadLine().Trim(), out identificadorGuid))
            Console.Write("Identificador inválido, digite novamente: ");

        return identificadorGuid;
    }

    public static DateTime ValidadorData()
    {
        DateTime data;

        while (!DateTime.TryParse(Console.ReadLine().Trim(), out data))
            Console.Write("Data informada inválida, digite novamente: ");

        return data;
    }
}
