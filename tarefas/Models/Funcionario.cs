using tarefas.Enums;

namespace tarefas.Models;

public class Funcionario : Colaborador
{
    public Funcionario(string idUsuario, string nome, DateTime dataNascimento) : base(idUsuario, nome, dataNascimento) { }

    public override CargoEnum Cargo { get; protected set; } = CargoEnum.Funcionario;
}
