using AeroportoCeuAzul.Enums;

namespace AeroportoCeuAzul.Models;

public class Voo
{
    public Voo(CompanhiaAerea companhiaAerea, string codigoUnico, string aeroportoOrigem, string aeroportoDestino, DateTime dataHoraPartida, int duracaoEstimada, StatusOperacionalVooEnum statusOperacional)
    {
        Id = Guid.NewGuid();
        CompanhiaAerea = companhiaAerea;
        CodigoUnico = codigoUnico;
        AeroportoOrigem = aeroportoOrigem;
        AeroportoDestino = aeroportoDestino;
        DataHoraPartida = dataHoraPartida;
        DuracaoEstimada = duracaoEstimada;
        StatusOperacional = statusOperacional;
    }

    public Guid Id { get; }
    public CompanhiaAerea CompanhiaAerea { get; }
    public string CodigoUnico { get; }
    public string AeroportoOrigem { get; }
    public string AeroportoDestino { get; private set; }
    public DateTime DataHoraPartida { get; private set; }
    public int DuracaoEstimada { get; private set; }
    public StatusOperacionalVooEnum StatusOperacional { get; private set; }

    public override string ToString() => $"Id: {Id} | Companhia Aérea: {CompanhiaAerea.Nome} | Voo: {CodigoUnico} | Origem: {AeroportoOrigem} | Destino: {AeroportoDestino} | Partida: {DataHoraPartida:d} | Duração Estimada: {DuracaoEstimada} min | Status Operacional: {StatusOperacional}";
}
