using GestaoLogistica.Enums;

namespace GestaoLogistica.Models;

public class Pedido
{
    public Pedido(string codigoUnico, decimal valor, double peso, DateTime dataCriacao, Cliente cliente)
    {
        Id = Guid.NewGuid();
        CodigoUnico = codigoUnico;
        Valor = valor;
        Peso = peso;
        DataCriacao = dataCriacao;
        Cliente = cliente;
        StatusPedido = StatusPedidoEnum.Pendente;
    }

    public Guid Id { get; }
    public string CodigoUnico { get; private set; }
    public decimal Valor { get; private set; }
    public double Peso { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public Cliente Cliente { get; private set; }
    public StatusPedidoEnum StatusPedido { get; private set; }

    public void AtualizarDados(string codigoUnico, decimal valor, double peso, DateTime dataCriacao, Cliente cliente)
    {
        CodigoUnico = codigoUnico;
        Valor = valor;
        Peso = peso;
        DataCriacao = dataCriacao;
        Cliente = cliente;
    }

    public void AlterarStatusPedido(StatusPedidoEnum statusPedido)
    {
        StatusPedido = statusPedido;
    }

    public override string ToString()
    {
        return $"Id: {Id} | Código Único do Pedido: {CodigoUnico} | Cliente: {Cliente.Nome}  | Valor: {Valor:c} | Peso: {Peso} | Data de Criação: {DataCriacao} | Status Pedido: {StatusPedido}";
    }

}
