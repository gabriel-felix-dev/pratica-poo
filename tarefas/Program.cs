using tarefas.Enums;
using tarefas.Models;

Usuario usuarioGestor = new Usuario(PerfilAcessoEnum.Funcionario, "arhur lanches", "arthur@lanches.com");
Usuario usuaruioSubordinado = new Usuario(PerfilAcessoEnum.Funcionario, "João", "joao@email.com");

usuaruioSubordinado.DefinirSuperiorDiretoDoColaborador(usuarioGestor.Id);

Console.WriteLine(usuarioGestor);
Console.WriteLine(usuaruioSubordinado);
