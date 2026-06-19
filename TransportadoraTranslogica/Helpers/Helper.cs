namespace TransportadoraTranslogica.Helpers;

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

    public static string ValidadorTelefone()
    {
        string telefone = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(telefone) || telefone.Length != 11 || !telefone.All(char.IsDigit) || !telefone.Substring(2, 1).Equals("9"))
        {
            Console.Write("\nNúmero de telefone inválido, digite novamente (apenas números, 11 dígitos com o 9 após o DDD): ");
            telefone = Console.ReadLine().Trim();
        }

        return telefone;
    }

    public static string ValidadorCpf()
    {
        string cpf = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
        {
            Console.Write("\nDocumento inválido, digite novamente (apenas dígitos): ");
            cpf = Console.ReadLine().Trim();
        }

        return cpf;
    }

    public static string ValidadorCnpj()
    {
        string cnpj = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14 || !cnpj.All(char.IsDigit))
        {
            Console.Write("\nDocumento inválido, digite novamente (apenas dígitos): ");
            cnpj = Console.ReadLine().Trim();
        }

        return cnpj;
    }

    public static string ValidadorCodigoIdentificacao()
    {
        string codigo = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(codigo) || codigo.Length != 4 || !codigo.All(char.IsDigit))
        {
            Console.Write("\nCódigo de Identificação inválido, digite novamente (apenas dígitos): ");
            codigo = Console.ReadLine().Trim();
        }

        return $"CG{codigo}";
    }

    public static string ValidadorNumeroOnu()
    {
        string codigo = Console.ReadLine().Trim();

        while (string.IsNullOrWhiteSpace(codigo) || codigo.Length != 4 || !codigo.All(char.IsDigit))
        {
            Console.Write("\nNúmero ONU inválido, digite novamente (apenas dígitos): ");
            codigo = Console.ReadLine().Trim();
        }

        return codigo;
    }

    public static int ValidadorNumeroInterio()
    {
        int numeroInteiro;

        while (!int.TryParse(Console.ReadLine().Trim(), out numeroInteiro) || numeroInteiro < 0)
            Console.Write("\nNúmero inválido, digite novamente: ");

        return numeroInteiro;
    }

    public static int ValidadorClasseRiscoCarga()
    {
        int numeroInteiro;

        while (!int.TryParse(Console.ReadLine().Trim(), out numeroInteiro) || numeroInteiro < 0 || numeroInteiro > 3)
            Console.Write("\nOpção inválida, digite novamente: ");

        return numeroInteiro;
    }

    public static int ValidadorStatusOperacionalCarga()
    {
        int numeroInteiro;

        while (!int.TryParse(Console.ReadLine().Trim(), out numeroInteiro) || numeroInteiro < 0 || numeroInteiro > 4)
            Console.Write("\nOpção inválida, digite novamente: ");

        return numeroInteiro;
    }

    public static int ValidadorTipoCargaPerigosa()
    {
        int numeroInteiro;

        while (!int.TryParse(Console.ReadLine().Trim(), out numeroInteiro) || numeroInteiro < 0 || numeroInteiro > 3)
            Console.Write("\nOpção inválida, digite novamente: ");

        return numeroInteiro;
    }

    public static double ValidadorDouble()
    {
        double numero;

        while (!double.TryParse(Console.ReadLine().Trim(), out numero) || numero < 0)
            Console.Write("\nNúmero inválido, digite novamente: ");

        return numero;
    }

    public static decimal ValidadorDecimal()
    {
        decimal numeroDecimal;

        while (!decimal.TryParse(Console.ReadLine().Trim(), out numeroDecimal) || numeroDecimal < 0)
            Console.Write("\nNúmero inválido, digite novamente: ");

        return numeroDecimal;
    }

    public static bool ValidadorListaVazia<T>(List<T> lista, string texto)
    {
        if (lista.Count == 0)
        {
            Console.Write($"\nNenhum item cadastrado na lista de {texto}. \n");
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
        Guid identificadorGuid;

        while (!Guid.TryParse(Console.ReadLine().Trim(), out identificadorGuid))
            Console.Write("\nIdentificador inválido, digite novamente: ");

        return identificadorGuid;
    }

    public static int ValidadorMenuPrincipal()
    {
        int opcaoMenu;

        while (!int.TryParse(Console.ReadLine().Trim(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > 3)
            Console.Write("\nOpção inválida, digite novamente: ");

        return opcaoMenu;
    }

    public static int ValidadorMenuCliente()
    {
        int opcaoMenu;

        while (!int.TryParse(Console.ReadLine().Trim(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > 5)
            Console.Write("\nOpção inválida, digite novamente: ");

        return opcaoMenu;
    }

    public static int ValidadorMenuCarga()
    {
        int opcaoMenu;

        while (!int.TryParse(Console.ReadLine().Trim(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > 5)
            Console.Write("\nOpção inválida, digite novamente: ");

        return opcaoMenu;
    }

    public static int ValidadorMenuFuncionalidade()
    {
        int opcaoMenu;

        while (!int.TryParse(Console.ReadLine().Trim(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > 5)
            Console.Write("\nOpção inválida, digite novamente: ");

        return opcaoMenu;
    }

    static void ReduzirTempo() => Thread.Sleep(1500);
}

