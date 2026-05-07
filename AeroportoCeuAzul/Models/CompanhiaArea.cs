using AeroportoCeuAzul.Enums;

namespace AeroportoCeuAzul.Models;

public class CompanhiaArea
{
    public CompanhiaArea(string iata, string nome, string paisOrigem)
    {
        Id = Guid.NewGuid();
        IATA = iata;
        Nome = nome;
        PaisOrigem = paisOrigem;
        StatusCadastro = StatusCadastroEnum.Ativo;
    }

    public Guid Id { get; }
    public string IATA { get; }
    public string Nome { get; private set; }
    public string PaisOrigem { get; private set; }
    public StatusCadastroEnum StatusCadastro { get; private set; }

    private readonly List<Voo> _voos = [];
}
