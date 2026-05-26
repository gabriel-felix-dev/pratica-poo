using GestaoLogistica.Enums;

namespace GestaoLogistica.Models;

public class Entrega
{
    public Entrega(DateTime dataColeta, int prazoEstimadoEmDias, string enderecoDestino, Transportadora transportadora, Pedido pedido)
    {
        Id = Guid.NewGuid();
        DataColeta = dataColeta;
        PrazoEstimadoEmDias = prazoEstimadoEmDias;
        EnderecoDestino = enderecoDestino;
        StatusEntrega = StatusEntregaEnum.Coletado;
        Pedido = pedido;
        Transportadora = transportadora;
    }

    public Guid Id { get; }
    public Transportadora Transportadora { get; private set; }
    public Pedido Pedido { get; private set; }
    public DateTime DataColeta { get; private set; }
    public int PrazoEstimadoEmDias { get; private set; }
    public string EnderecoDestino { get; private set; }
    public StatusEntregaEnum StatusEntrega { get; private set; }

    public void AlterarStatusEntrega(StatusEntregaEnum statusEntrega)
    {
        StatusEntrega = statusEntrega;
    }

    public void AtualizarDados(DateTime dataColeta, int prazoEstimadoEmDias, string enderecoDestino, Transportadora transportadora, Pedido pedido)
    {
        DataColeta = dataColeta;
        PrazoEstimadoEmDias = prazoEstimadoEmDias;
        EnderecoDestino = enderecoDestino;
        Pedido = pedido;
        Transportadora = transportadora;
    }

    public override string ToString()
    {
        return $"Id: {Id} | Transpostadora: {Transportadora.Nome} | Número do Pedido: {Pedido.CodigoUnico} | Data Coleta: {DataColeta} | Prazo Estimado para Entrega em Dias: {PrazoEstimadoEmDias} | Endereço de Destino: {EnderecoDestino} | Status da Entrega: {StatusEntrega}";
    }
}
