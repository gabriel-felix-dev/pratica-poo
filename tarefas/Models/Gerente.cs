using tarefas.Enums;

namespace tarefas.Models;

public class Gerente : Colaborador
{
    public Gerente(string idUsuario, string nome, DateTime dataNascimento) : base(idUsuario, nome, dataNascimento) { }
    public override CargoEnum Cargo { get; protected set; } = CargoEnum.Gerente;
}
