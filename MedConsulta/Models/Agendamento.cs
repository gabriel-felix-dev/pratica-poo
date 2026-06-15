using MedConsulta.Enums;

namespace MedConsulta.Models;

public class Agendamento(TipoAtendimentoEnum tipoAtendimento, decimal valorCobrado, DateTime dataHoraConfirmacao, Paciente paciente)
{
    public Guid Id { get; } = Guid.NewGuid();
    public TipoAtendimentoEnum TipoAtendimento { get; private set; } = tipoAtendimento;
    public decimal ValorCobrado { get; private set; } = valorCobrado;
    public DateTime DataHoraConfirmacao { get; private set; } = dataHoraConfirmacao;
    public Paciente Paciente { get; private set; } = paciente;

    public void AlterarDados(TipoAtendimentoEnum tipoAtendimento, decimal valorCobrado, DateTime dataHoraConfirmacao)
    {
        TipoAtendimento = tipoAtendimento;
        ValorCobrado = valorCobrado;
        DataHoraConfirmacao = dataHoraConfirmacao;
    }

    public void AlteracaoPaciente(Paciente paciente) => Paciente = paciente;

    public override string ToString() => $"Id: {Id} | Tipo de Atendimento: {TipoAtendimento} | Valor Cobrado: {ValorCobrado:c} | Data e Hora da Confirmação: {DataHoraConfirmacao:d} | Paciente: {Paciente.Nome}";
}
