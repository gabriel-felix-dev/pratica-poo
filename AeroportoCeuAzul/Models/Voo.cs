using AeroportoCeuAzul.Enums;

namespace AeroportoCeuAzul.Models;

public class Voo
{
    public Voo(string codigoUnico, string aeroportoOrigem, string aeroportoDestino, DateTime dataHorarioPartida, int duracaoViagem, CompanhiaArea companhiaArea, StatusOperacionalVooEnum statusOperacionalVoo)
    {
        Id = Guid.NewGuid();
        CodigoUnico = codigoUnico;
        AeroportoOrigem = aeroportoOrigem;
        AeroportoDestino = aeroportoDestino;
        DataHoraPartida = dataHorarioPartida;
        DuracaoViagem = duracaoViagem;
        CompanhiaArea = companhiaArea;
        StatusOperacionalVoo = statusOperacionalVoo;
        StatusCadastro = StatusCadastroEnum.Ativo;
    }

    public Guid Id { get; }
    public string CodigoUnico { get; }
    public string AeroportoOrigem { get; }
    public string AeroportoDestino { get; }
    public DateTime DataHoraPartida { get; private set; }
    public int DuracaoViagem { get; private set; }
    public CompanhiaArea CompanhiaArea { get; }
    public StatusOperacionalVooEnum StatusOperacionalVoo { get; private set; }
    public StatusCadastroEnum StatusCadastro { get; private set; }

}
