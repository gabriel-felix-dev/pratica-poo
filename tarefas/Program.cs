using tarefas.Enums;
using tarefas.Models;

Usuario usuarioGestor = new Usuario(PerfilAcessoEnum.Gerente, "arhur lanches", "arthur@lanches.com", DateTime.Parse("2001-01-01"));
Usuario usuarioSubordinado = new Usuario(PerfilAcessoEnum.Funcionario, "João", "joao@email.com", DateTime.Parse("2001-01-01"));
//Usuario usuarioAdministrador = new Usuario(PerfilAcessoEnum.Administrador, string.Empty, "adm@email.com", DateTime.Parse("2001-01-01"));

usuarioSubordinado.DefinirSuperiorDiretoDoColaborador(usuarioGestor.Colaborador);

if (usuarioGestor.Colaborador is Gerente gerente)
    gerente.AtribuirTarefa(usuarioSubordinado.Colaborador, "Finalizar Relatório", "Finalizar o relatório mensal de vendas", TipoTarefaEnum.Recorrente);

Console.WriteLine(usuarioGestor);
Console.WriteLine(usuarioSubordinado);
//Console.WriteLine(usuarioAdministrador);

usuarioSubordinado.Colaborador.ListarTarefas().ForEach(t => Console.WriteLine(t.ToString()));
