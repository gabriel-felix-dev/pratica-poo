using AeroportoCeuAzul.Helpers;
using AeroportoCeuAzul.Models;

List<Passageiro> passageiros = [];

while (true)
{
    Console.WriteLine("#### - Aeroporto Internacional Céu Azul - ####\n");

    Console.WriteLine("### - Passageiro - ###\n");

    Console.WriteLine("1 - Cadastrar Passageiro");
    Console.WriteLine("2 - Listar Passageiro");
    Console.WriteLine("3 - Buscar Passageiro");
    Console.WriteLine("4 - Deletar Passageiro \n");

    Console.WriteLine("0 - Sair\n");

    Console.Write("Digite a opção desejada: ");
    int opcao = Helper.ValidaNumeroInteiro();

    switch (opcao)
    {
        case 1:

            DateTime dataNascimentoPassageiro = DateTime.Today;
            string cpfPassageiro = "10110110112";
            string passaporteNumero = "52525252";

            Console.Write("\nInforme o nome do passageiro: ");
            string nomePassageiro = Console.ReadLine();
            Helper.ValidaTexto(nomePassageiro);

            Passageiro passageiro = new Passageiro(nomePassageiro, dataNascimentoPassageiro, cpfPassageiro, passaporteNumero);

            passageiros.Add(passageiro);
            break;
        case 2:
            ImprimeLista(passageiros);
            break;
        case 3:

        default:
            Console.WriteLine("Sistema encerrado");
            Environment.Exit(0);
            break;
    }
}

void ImprimeLista<T>(List<T> ts)
{
    Console.WriteLine("\nLista de passageiros cadastrados: \n");
    ts.ForEach(x => Console.WriteLine($"# - {x}"));

}
