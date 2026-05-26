using GestaoLogistica.Enums;

namespace GestaoLogistica.Models;

public class Transportadora
{
    public Transportadora(string codigoUnico, string nome, string estadoOperacao, ModalidadeTransporteEnum modalidadeTransporte)
    {
        Id = Guid.NewGuid();
        CodigoUnico = codigoUnico;
        Nome = nome;
        EstadoOperacao = estadoOperacao;
        ModalidadeTransporte = modalidadeTransporte;
    }

    public Guid Id { get; }
    public string CodigoUnico { get; private set; }
    public string Nome { get; private set; }
    public string EstadoOperacao { get; private set; }
    public ModalidadeTransporteEnum ModalidadeTransporte { get; private set; }

    public void AtualizarDados(string codigoUnico, string nome, string estadoOperacao, ModalidadeTransporteEnum modalidadeTransporte)
    {
        CodigoUnico = codigoUnico;
        Nome = nome;
        EstadoOperacao = estadoOperacao;
        ModalidadeTransporte = modalidadeTransporte;
    }

    public override string ToString()
    {
        return $"Id: {Id} | Nome: {Nome} | Código Único Transportadora: {CodigoUnico} | Estado de Operação: {EstadoOperacao} | Modalidade de Transporte: {ModalidadeTransporte}";
    }
}
