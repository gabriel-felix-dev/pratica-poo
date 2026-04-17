using tarefas.Enums;

namespace tarefas.Models;

public abstract class Colaborador
{
    private readonly List<Tarefa> _tarefas = [];

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
    public IReadOnlyList<Tarefa> Tarefas { get => _tarefas.AsReadOnly(); }
    //public List<Tarefa> Tarefas { get; private set; } = []; // Todo Colaborador tem uma lista de Tarefas, mas só o gerente pode atribuir tarefa;

    public void AtualizarDadosPessoais(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public void FinalizarTarefa(string idTarefa)
    {
        var tarefaParaFinalizar = _tarefas?.FirstOrDefault(t => t.Id == idTarefa);
        tarefaParaFinalizar?.Concluir();
    }

    public void IniciarTarefa(string idTarefa)
    {
        var tarefaParaIniciar = _tarefas?.FirstOrDefault(t => t.Id == idTarefa);
        tarefaParaIniciar?.Concluir();
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

    public void AdicionarTarefa(string titulo, string descricao, TipoTarefaEnum tipo, string idGerente)
    {
        _tarefas.Add(new Tarefa(titulo, descricao, tipo, idGerente, Id));
    }

    public List<Tarefa> ListarTarefas()
    {
        if (Tarefas.Count() == 0)
        {
            Console.WriteLine($"\nNenhuma tarefa atribuída a este colaborador");
            return [];
        }

        return Tarefas.ToList();
    }

    public List<Tarefa> ListarTarefas(TarefasStatusEnum status)
    {
        if (Tarefas.Count() == 0)
        {
            Console.WriteLine($"\nNenhuma tarefa atribuída a este colaborador");
            return [];
        }

        return Tarefas.Where(t => t.TarefasStatus == status).ToList();
    }

    public override string ToString()
    {
        return Superior is null
        ? $"Nome: {Nome} | Cargo: {Cargo}"
        : $"Nome: {Nome} | Cargo: {Cargo} | Gestor: {Superior.Nome}";
    }

    //public string ObterCodigoGerenteResponsavelFormatado() => Superior?.Id.Substring(1, 7);

}
