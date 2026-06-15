using MedConsulta.Models;

List<Medico> medicos = [];
List<Consulta> consultas = [];
List<Paciente> pacientes = [];
List<Agendamento> agendamentos = [];


Console.WriteLine("#### - Clínica MedConsulta - ####\n");

Console.WriteLine("Escolha uma das opções: \n");

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
Console.WriteLine("9 - Alterar Médico da Consulta\n");
Console.WriteLine("10 - Alterar Informações da Consulta\n");
Console.WriteLine("11 - Excluir Consulta");

Console.WriteLine("\n#### - Paciente - ####\n");

Console.WriteLine("12 - Cadastrar Paciente\n");
Console.WriteLine("13 - Listar Pacientes Cadastrados\n");
Console.WriteLine("14 - Procurar Pacientes por Nome\n");
Console.WriteLine("15 - Procurar Pacientes por Nome Específico\n");
Console.WriteLine("16 - Alterar Cpf\n");
Console.WriteLine("17 - Alterar Número Carteirinha\n");
Console.WriteLine("18 - Alterar Dados do Paciente\n");
Console.WriteLine("19 - Excluir Paciente");

Console.WriteLine("\n#### - Agendamento - ####\n");

Console.WriteLine("20 - Cadastrar Agendamento\n");
Console.WriteLine("21 - Listar Agendamentos Cadastrados\n");
Console.WriteLine("22 - Alterar Dados de Agendamento\n");
Console.WriteLine("23 - Alterar Paciente \n");
Console.WriteLine("24 - Cadastrar Agendamento");

Console.WriteLine("\n#### - Funcionalidades - ####\n");

Console.WriteLine("25 - Ranking de Agendamentos\n");
Console.WriteLine("26 - Histórico de Consultas por Paciente\n");
Console.WriteLine("27 - Filtro por Tipo de Atendimento\n");

Console.WriteLine("\n0 - Sair\n");

Console.Write("\nDigite uma opção: \n");
