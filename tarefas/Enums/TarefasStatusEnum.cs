using System.ComponentModel;

namespace tarefas.Enums;

public enum TarefasStatusEnum
{
    [Description("Cadastrada")]
    Cadastrada = 1,
    [Description("Em andamento")]
    EmAndamento = 2,
    [Description("Concluída")]
    Concluida = 3,
}
