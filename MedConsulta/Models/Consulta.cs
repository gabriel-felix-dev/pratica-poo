using MedConsulta.Enums;

namespace MedConsulta.Models;

public class Consulta(string codigoUnico, LocalAtendimentoEnum localAtendimento, DateTime dataHoraPrevista, int duracao, StatusConsultaEnum statusConsulta, Medico medico)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string CodigoUnico { get; private set; } = codigoUnico;
    public LocalAtendimentoEnum LocalAtendimento { get; private set; } = localAtendimento;
    public DateTime DataHoraPrevista { get; private set; } = dataHoraPrevista;
    public int Duracao { get; private set; } = duracao;
    public StatusConsultaEnum StatusConsulta { get; private set; } = statusConsulta;
    public Medico Medico { get; private set; } = medico;

    public void AlterarCodigoUnico(string codigoUnico) => CodigoUnico = codigoUnico;

    public void AlterarMedico(Medico medico) => Medico = medico;

    public void AlterarInformacoes(LocalAtendimentoEnum localAtendimento, DateTime dataHoraPrevista, int duracao, StatusConsultaEnum statusConsulta)
    {
        LocalAtendimento = localAtendimento;
        DataHoraPrevista = dataHoraPrevista;
        Duracao = duracao;
        StatusConsulta = statusConsulta;
    }

    public override string ToString() => $"Id: {Id} | Código Consulta: {CodigoUnico} | Local de Atendimento: {LocalAtendimento} | Data e Hora Previstas: {DataHoraPrevista:d} | Duração: {Duracao} | Status da Consulta: {StatusConsulta} | Médico: {Medico.Nome}";
}
