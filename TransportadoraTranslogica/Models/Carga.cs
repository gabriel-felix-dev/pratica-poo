using Enums;

namespace Models;

public class Carga
{
    public string CodigoRastreio { get; private set; }
    public Cliente Cliente { get; private set; }
    public Viagem Viagem { get; private set; }
    public double PesoKg { get; private set; }
    public decimal ValorDeclarado { get; private set; }
    public TipoCargaEnum Tipo { get; private set; }
    public StatusCargaEnum Status { get; private set; }
    public TipoDestinoEnum TipoDestino { get; private set; }
    public string? CidadeParadaEntrega { get; private set; }
    public string? EnderecoDireto { get; private set; }
    public DateTime DataDespacho { get; private set; }

    public Carga(string codigoRastreio, Cliente cliente, Viagem viagem,
                 double pesoKg, decimal valorDeclarado, TipoCargaEnum tipo,
                 StatusCargaEnum status, TipoDestinoEnum tipoDestino,
                 DateTime dataDespacho, string? cidadeParadaEntrega = null,
                 string? enderecoDireto = null)
    {
        CodigoRastreio = codigoRastreio;
        Cliente = cliente;
        Viagem = viagem;
        PesoKg = pesoKg;
        ValorDeclarado = valorDeclarado;
        Tipo = tipo;
        Status = status;
        TipoDestino = tipoDestino;
        DataDespacho = dataDespacho;
        CidadeParadaEntrega = cidadeParadaEntrega;
        EnderecoDireto = enderecoDireto;
    }

    public string LocalEntrega() =>
        TipoDestino == TipoDestinoEnum.ParadaRoteiro
            ? CidadeParadaEntrega ?? "Parada não informada"
            : EnderecoDireto ?? "Endereço não informado";

    public override string ToString() =>
        $"{CodigoRastreio} | {Cliente.Nome} | {Tipo} | {PesoKg:N1} kg | {Status}";
}
