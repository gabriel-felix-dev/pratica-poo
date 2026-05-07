using AeroportoCeuAzul.Enums;
using AeroportoCeuAzul.Interfaces;

namespace AeroportoCeuAzul.Models;

public class CompanhiaAerea : IAlterarStatusCadastro
{
    public CompanhiaAerea(string iata, string nome, string paisOrigem)
    {
        Id = Guid.NewGuid();
        IATA = iata;
        Nome = nome;
        PaisOrigem = paisOrigem;
        StatusCadastro = StatusCadastroEnum.Ativo;
    }

    public Guid Id { get; }
    public string IATA { get; private set; }
    public string Nome { get; private set; }
    public string PaisOrigem { get; private set; }
    public StatusCadastroEnum StatusCadastro { get; private set; }

    public void AlterarDados(string iata, string nome, string paisOrigem)
    {
        IATA = iata;
        Nome = nome;
        PaisOrigem = paisOrigem;
    }

    public void AlterarStatusCadastro() => StatusCadastro = StatusCadastroEnum.Inativo;

    public override string ToString() => $"Id: {Id} | Companhia Aérea: {Nome} | IATA: {IATA} | País de Origem: {PaisOrigem} | Status: {StatusCadastro}";
}
