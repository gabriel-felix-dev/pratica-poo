using MedConsulta.Helpers;
using MedConsulta.Models;

List<Medico> medicos = [];
List<Consulta> consultas = [];
List<Paciente> pacientes = [];
List<Agendamento> agendamentos = [];

Console.WriteLine("#### - Clínica MedConsulta - ####");

while (true)
{
    Menu();
    var opcao = Helper.ValidadorMenu();

    switch (opcao)
    {
        case 1:
            Console.Write("\nInforme o nome do médico: ");
            var nomeMedico = Helper.ValidadorTexto();

            Console.Write("\nInforme o Crm do médico (4 a 7 dígitos): ");
            var crmMedico = Helper.ValidadorCrm();

            if (medicos.Any(x => x.Crm.Equals(crmMedico)))
            {
                Console.WriteLine("\nCRM já cadastrado.");
                ReduzirTempo();
                continue;
            }

            Console.Write("\nInforme a Especialidade do médico: ");
            var especialidadeMedico = Helper.ValidadorTexto();

            Medico medico = new(crmMedico, nomeMedico, especialidadeMedico);

            medicos.Add(medico);

            MensagemSucesso();
            break;
        case 2:
            if (Helper.ValidadorListaVazia(medicos, "Médico"))
                continue;

            ListarItens(medicos, "Medico");
            break;
        case 3:
            medico = ValidadorMedico();

            if (Helper.ValidadorObjetoNulo(medico))
                continue;

            Console.Write("\nInforme o nome do médico: ");
            nomeMedico = Helper.ValidadorTexto();

            Console.Write("\nInforme a Especialidade do médico: ");
            especialidadeMedico = Helper.ValidadorTexto();

            medico.AtulizarDados(nomeMedico, especialidadeMedico);

            MensagemSucesso();
            break;
        case 4:
            medico = ValidadorMedico();

            if (Helper.ValidadorObjetoNulo(medico))
                continue;

            Console.Write("\nInforme o Crm do médico (4 a 7 dígitos): ");
            crmMedico = Helper.ValidadorCrm();

            if (medicos.Any(x => x.Crm.Equals(crmMedico)))
            {
                Console.WriteLine("\nCRM já cadastrado.");
                ReduzirTempo();
                continue;
            }

            medico.AtulizarCrm(crmMedico);

            MensagemSucesso();
            break;
        case 5:
            medico = ValidadorMedico();

            if (Helper.ValidadorObjetoNulo(medico))
                continue;

            var posicao = medicos.IndexOf(medico);

            medicos.RemoveAt(posicao);
            MensagemSucesso();
            break;
        case 6:
            Console.Write("\nInforme o código consulta (4 dígitos - Exemplo:  0512): ");
            var codigoConsulta = Helper.ValidadorNumeroConsulta();

            if (consultas.Any(x => x.CodigoUnico.Equals(codigoConsulta)))
            {
                Console.WriteLine("\nConsulta já cadastrada.");
                ReduzirTempo();
                continue;
            }

            medico = ValidadorMedico();

            if (Helper.ValidadorObjetoNulo(medico))
                continue;

            break;
        case 7:

            break;
        case 8:

            break;
        case 9:

            break;
        case 10:

            break;
        default:
            Console.WriteLine("Sistema encerrado.");
            ReduzirTempo();
            Environment.Exit(0);
            break;
    }
    continue;
}

void MensagemSucesso()
{
    Console.WriteLine($"\nAção concluída com sucesso!");
    ReduzirTempo();
}

void ListarItens<T>(List<T> lista, string texto)
{
    Console.WriteLine($"\nListar {texto} Cadastrados: \n");
    lista.ForEach(x => Console.WriteLine($"# - {x}"));
    ReduzirTempo();
}

Medico ValidadorMedico()
{
    if (Helper.ValidadorListaVazia(medicos, "Médico"))
        return null;

    ListarItens(medicos, "Medico");

    Console.Write("\nInforme o Id do médico: ");
    var idMedico = Helper.ValidadorGuid();

    var medico = medicos.FirstOrDefault(x => x.Id.Equals(idMedico));

    return medico;
}

void Menu()
{
    Console.WriteLine("\nEscolha uma das opções: \n");

    Console.WriteLine("#### - Médico - ####\n");

    Console.WriteLine("1 - Cadastrar Médico\n");
    Console.WriteLine("2 - Listar Médicos Cadastrados\n");
    Console.WriteLine("3 - Alterar Nome e Especialidade\n");
    Console.WriteLine("4 - Alterar CRM\n");
    Console.WriteLine("5 - Excluir Médico");

    Console.WriteLine("\n#### - Consulta - ####\n");

    Console.WriteLine("6 - Cadastrar Consulta\n");
    Console.WriteLine("7 - Listar Consultas Cadastradas\n");
    Console.WriteLine("8 - Alterar Código de uma Consulta\n");
    Console.WriteLine("9 - Alterar Informações da Consulta\n");
    Console.WriteLine("10 - Excluir Consulta");

    Console.WriteLine("\n#### - Paciente - ####\n");

    Console.WriteLine("11 - Cadastrar Paciente\n");
    Console.WriteLine("12 - Listar Pacientes Cadastrados\n");
    Console.WriteLine("13 - Procurar Pacientes por Nome\n");
    Console.WriteLine("14 - Procurar Pacientes por Nome Específico\n");
    Console.WriteLine("15 - Alterar Cpf\n");
    Console.WriteLine("16 - Alterar Número Carteirinha\n");
    Console.WriteLine("17 - Alterar Dados do Paciente\n");
    Console.WriteLine("18 - Excluir Paciente");

    Console.WriteLine("\n#### - Agendamento - ####\n");

    Console.WriteLine("19 - Cadastrar Agendamento\n");
    Console.WriteLine("20 - Listar Agendamentos Cadastrados\n");
    Console.WriteLine("21 - Alterar Dados de Agendamento\n");
    Console.WriteLine("22 - Cadastrar Agendamento");

    Console.WriteLine("\n#### - Funcionalidades - ####\n");

    Console.WriteLine("23 - Ranking de Agendamentos\n");
    Console.WriteLine("24 - Histórico de Consultas por Paciente\n");
    Console.WriteLine("25 - Filtro por Tipo de Atendimento\n");

    Console.WriteLine("0 - Sair");

    Console.Write("\nDigite uma opção: ");
}

void ReduzirTempo() => Thread.Sleep(1500);
