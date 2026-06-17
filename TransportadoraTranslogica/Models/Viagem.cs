using Enums;

namespace Models;

public class Viagem
{
    public string Codigo { get; private set; }
    public Motorista Motorista { get; private set; }
    public string PlacaVeiculo { get; private set; }
    public string ModeloVeiculo { get; private set; }
    public double CapacidadeKg { get; private set; }
    public string FilialOrigem { get; private set; }
    public DateTime DataSaida { get; private set; }
    public DateTime? DataChegada { get; private set; }
    public int KmInicial { get; private set; }
    public int? KmFinal { get; private set; }
    public StatusViagemEnum Status { get; private set; }
    public List<string> RoteiroCidades { get; private set; }

    public Viagem(string codigo, Motorista motorista, string placaVeiculo,
                  string modeloVeiculo, double capacidadeKg, string filialOrigem,
                  DateTime dataSaida, int kmInicial, List<string> roteiroCidades,
                  StatusViagemEnum status = StatusViagemEnum.Planejada,
                  DateTime? dataChegada = null, int? kmFinal = null)
    {
        Codigo = codigo;
        Motorista = motorista;
        PlacaVeiculo = placaVeiculo;
        ModeloVeiculo = modeloVeiculo;
        CapacidadeKg = capacidadeKg;
        FilialOrigem = filialOrigem;
        DataSaida = dataSaida;
        KmInicial = kmInicial;
        RoteiroCidades = roteiroCidades;
        Status = status;
        DataChegada = dataChegada;
        KmFinal = kmFinal;
    }

    public int? DistanciaPercorrida() =>
        KmFinal.HasValue ? KmFinal.Value - KmInicial : null;

    public override string ToString() =>
        $"{Codigo} | {Motorista.Nome} | {PlacaVeiculo} | {FilialOrigem} | {Status}";
}
