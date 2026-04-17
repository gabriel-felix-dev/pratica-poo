using tarefas.Enums;
using tarefas.Helpers;

namespace tarefas.Models;

public class Tarefa
{
    public Tarefa(string titulo, string descricao, TipoTarefaEnum tipo, string idGerenteResponsavelCadastro, string idFuncionarioResponsavel)
    {
        Id = Guid.NewGuid().ToString();
        IdGerenteResponsavelCadastro = idGerenteResponsavelCadastro;
        IdFuncionarioResponsavel = idFuncionarioResponsavel;
        Titulo = titulo;
        Descricao = descricao;
        TipoTarefa = tipo;
        DataCriacao = DateTime.Today;
        TarefasStatus = TarefasStatusEnum.Cadastrada;
        // Concluida = false;
    }

    public string Id { get; }
    public string Titulo { get; }
    public TarefasStatusEnum TarefasStatus { get; private set; }
    public string Descricao { get; }
    public TipoTarefaEnum TipoTarefa { get; }
    public DateTime DataCriacao { get; }
    public DateTime DataFinalizacao { get; private set; }
    public string IdGerenteResponsavelCadastro { get; private set; }
    public string IdFuncionarioResponsavel { get; private set; }
    // public bool Concluida { get; private set; }

    public void Concluir()
    {
        TarefasStatus = TarefasStatusEnum.Concluida;
        DataFinalizacao = DateTime.Today;
    }

    public void IniciarTarefa() => TarefasStatus = TarefasStatusEnum.EmAndamento;


    public override string ToString() => $"Id:{Id} | Título: {Titulo} | Descrição: {Descricao} | Tipo da Tarefa: {TipoTarefa} | Data Criação: {DataCriacao} | DataFinalizacao: {DataFinalizacao} | Status: {TarefasStatus.PegaDescricaoEnum()}";

}
