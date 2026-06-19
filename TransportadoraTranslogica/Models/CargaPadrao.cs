namespace TransportadoraTranslogica.Models;

public class CargaPadrao(string codigoIdentificacao, double peso, decimal valorDeclarado, Cliente clienteDestinatario) : Carga(codigoIdentificacao, peso, valorDeclarado, clienteDestinatario)
{
    public override void CalcularFrete()
    {
        decimal valorFrete = (decimal)Peso * 5.00m;

        AtuliazarFrete(valorFrete);
    }

    public override string ToString() => $"Id: {Id} | Peso: {Peso} | Valor do Frete: {Frete:c} | Valor Declarado: {ValorDeclarado:c} | Cliente Destinatário: {ClienteDestinatario.Nome} | Status Operacional: {StatusOperacional}";
}
