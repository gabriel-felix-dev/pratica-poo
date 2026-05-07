namespace AeroportoCeuAzul.Helpers;

public static class Helper
{
    public static string ValidadorTexto()
    {
        string texto = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(texto))
        {
            Console.Write("\nInformação inválida, digite novamente: ");
            texto = Console.ReadLine().Trim();
        }

        return texto;
    }

    public static int ValidadorNumeroInteiro()
    {
        int numero;
        while (!int.TryParse(Console.ReadLine().Trim(), out numero))
            Console.Write("\nNúmero inválido, digite novamente: ");

        return numero;
    }

    public static DateTime ValidadorData()
    {
        DateTime data;
        while (!DateTime.TryParse(Console.ReadLine().Trim(), out data))
            Console.Write("\nData inválida, digite novamente (formato: dd/MM/yyyy): ");

        return data;
    }

    public static Guid ValidadorGuid()
    {
        Guid guid;
        while (!Guid.TryParse(Console.ReadLine().Trim(), out guid))
            Console.Write("\nID inválido, digite novamente: ");

        return guid;
    }

    public static string ValidadorNumeroPassaporte()
    {
        string numeroPassaporte = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(numeroPassaporte) || numeroPassaporte.Length > 9 || numeroPassaporte.Length < 6)
        {
            Console.Write("\nNúmero de passaporte inválido, digite novamente (Máximo de 9 caracteres e mínimo 6 de caracteres): ");
            numeroPassaporte = Console.ReadLine().Trim();
        }

        return numeroPassaporte;
    }

    public static string ValidadorCpf()
    {
        string cpf = Console.ReadLine().Trim();
        while (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            Console.Write("\nCPF inválido, digite novamente (apenas números, 11 dígitos): ");
            cpf = Console.ReadLine().Trim();
        }

        return cpf;
    }

    public static string ValidadorIATA()
    {
        string iata = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(iata) || iata.Length != 2 || !char.IsLetter(iata[0]) || !char.IsDigit(iata[1]))
        {
            Console.Write("\nCódigo IATA inválido, digite novamente (2 caracteres - A1): ");
            iata = Console.ReadLine().Trim().ToUpper();
        }

        iata = iata.Substring(0, 1).ToUpper() + iata.Substring(1);

        return iata;
    }

    public static string ValidadorCodigoUnicoVoo()
    {
        string codigoUnico = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(codigoUnico) || codigoUnico.Length != 6 || !codigoUnico.Substring(0, 2).All(char.IsLetter) || !codigoUnico.Substring(2, 4).All(char.IsDigit))
        {
            Console.Write("\nCódigo único inválido, digite novamente (formato: 2 letras seguidas de 4 números, ex: AA1234): ");
            codigoUnico = Console.ReadLine().Trim().ToUpper();
        }

        codigoUnico = codigoUnico.Substring(0, 2).ToUpper() + codigoUnico.Substring(2);
        return codigoUnico;
    }

    public static bool ValidaQuantidadeLista<T>(List<T> lista)
    {
        if (lista.Count == 0)
        {
            Console.Write("\nNenhum item cadastrado na lista. \n");
            return true;
        }

        return false;
    }

    public static int ValidadorStatusOperacional()
    {
        int numero;
        while (!int.TryParse(Console.ReadLine().Trim(), out numero) || numero < 1 || numero > 3)
            Console.Write("\nOpção inválida, digite novamente: ");

        return numero;
    }

    public static int ValidadorClasseViagem()
    {
        int numero;
        while (!int.TryParse(Console.ReadLine().Trim(), out numero) || numero < 1 || numero > 3)
            Console.Write("\nOpção inválida, digite novamente: ");

        return numero;
    }

    public static int ValidadorDuracaoVoo()
    {
        int numero;

        while (!int.TryParse(Console.ReadLine().Trim(), out numero) || numero < 0 || numero == 0)
            Console.Write("\nDuração de voo inválida, digite novamente: ");

        return numero;
    }

    public static int ValidadorNumeroPoltrona()
    {
        int numero;

        while (!int.TryParse(Console.ReadLine().Trim(), out numero) || numero < 0 || numero == 0)
            Console.Write("\nNúmero da poltrona inválido, digite novamente: ");

        return numero;
    }

}
