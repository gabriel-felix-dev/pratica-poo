using tarefas.Enums;
using tarefas.Models;

Usuario usuarioGestor = new Usuario(PerfilAcessoEnum.Gerente, "arhur lanches", "arthur@lanches.com", DateTime.Parse("2001-01-01"));
Usuario usuaruioSubordinado = new Usuario(PerfilAcessoEnum.Funcionario, "João", "joao@email.com", DateTime.Parse("2001-01-01"));
Usuario usuarioAdministrador = new Usuario(PerfilAcessoEnum.Administrador, string.Empty, "adm@email.com", DateTime.Parse("2001-01-01"));

usuaruioSubordinado.DefinirSuperiorDiretoDoColaborador(usuarioGestor.Colaborador);

Console.WriteLine(usuarioGestor);
Console.WriteLine(usuaruioSubordinado);
Console.WriteLine(usuarioAdministrador);
