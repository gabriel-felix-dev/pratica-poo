using tarefas.Enums;

namespace tarefas.Models;

public abstract class Colaborador
{
    public Colaborador(string idUsuario, string nome, DateTime dataNascimento)
    {
        Id = Guid.NewGuid().ToString();
        IdUsuario = idUsuario;
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public string Id { get; }
    public string IdUsuario { get; set; }
    public string Nome { get; private set; }
    public Gerente Superior { get; private set; }
    public DateTime DataNascimento { get; private set; }

    public abstract CargoEnum Cargo { get; protected set; }
    public List<Tarefa> Tarefas { get; } = []; // Todo Colaborador tem uma lista de Tarefas, mas só o gerente pode atribuir tarefa;

    public void AtualizarDadosPessoais(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public void DefinirSuperiorDireto(Colaborador colaborador)
    {
        if (colaborador is not Gerente gerente) // Valida para que o colaborador do tipo Funcionario seja superior. Somente um gerente pode ser superior
        {
            Console.WriteLine("O colaborador deve ser um gerente para ser definido como superior direto");
            return;
        }

        Superior = gerente;
    }

    public void AdicionarTarefa(Tarefa tarefa) => Tarefas.Add(tarefa);

    public List<Tarefa> ListarTarefas()
    {
        if (Tarefas.Count() == 0)
        {
            Console.WriteLine($"\nNenhuma tarefa atribuída a este colaborador");
            return [];
        }

        return Tarefas;
    }
    
    public List<Tarefa> ListarTarefas(bool status)
    {
        if (Tarefas.Count() == 0)
        {
            Console.WriteLine($"\nNenhuma tarefa atribuída a este colaborador");
            return [];
        }

        return Tarefas;
    }

    //public string ObterCodigoGerenteResponsavelFormatado() => Superior?.Id.Substring(1, 7);

}
