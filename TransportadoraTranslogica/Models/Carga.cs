using TransportadoraTranslogica.Enums;

namespace TransportadoraTranslogica.Models;

public abstract class Carga(string codigoIdentificacao, double peso, decimal valorDeclarado, Cliente clienteDestinatario)
{
    public Guid Id { get; } = Guid.NewGuid();
    public Cliente ClienteDestinatario { get; private set; } = clienteDestinatario;
    public string CodigoIdentificacao { get; private set; } = codigoIdentificacao;
    public double Peso { get; private set; } = peso;
    public decimal ValorDeclarado { get; private set; } = valorDeclarado;
    public StatusOperacionalEnum StatusOperacional { get; private set; } = StatusOperacionalEnum.Pendente;
    public string TipoCargaEnum { get; set; }
    public virtual decimal Frete { get; private set; }
    public abstract void CalcularFrete();

    public void AlterarCodigoIdentificacao(string codigoIdentificacao) => CodigoIdentificacao = codigoIdentificacao;

    public virtual void AlterarDados(double peso, decimal valorDeclarado, Cliente clienteDestinatario, StatusOperacionalEnum statusOperacional)
    {
        Peso = peso;
        ValorDeclarado = valorDeclarado;
        ClienteDestinatario = clienteDestinatario;
        StatusOperacional = statusOperacional;
    }

    protected void AtuliazarFrete(decimal frete) => Frete = frete;

    public override string ToString() => $"Id: {Id} | Peso: {Peso} | Valor Declarado: {ValorDeclarado:c} | Cliente Destinatário: {ClienteDestinatario.Nome} | Status Operacional: {StatusOperacional}";
}
