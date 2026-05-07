using AeroportoCeuAzul.Enums;

namespace AeroportoCeuAzul.Models;

public class Embarque
{
    public Embarque(StatusOperacionalVooEnum statusOperacionalVoo, int numeroPoltrona)
    {
        Id = Guid.NewGuid();
        StatusOperacionalVoo = statusOperacionalVoo;
        NumeroPoltrona = numeroPoltrona;
        DataEmissaoBilhete = DateTime.Now;
        StatusCadastro = StatusCadastroEnum.Ativo;
    }

    public Guid Id { get; set; }
    public StatusOperacionalVooEnum StatusOperacionalVoo { get; }
    public int NumeroPoltrona { get; private set; }
    public DateTime DataEmissaoBilhete { get; }
public StatusCadastroEnum StatusCadastro { get; private set; }

    private readonly List<Passageiro> _passageiros = [];
}
