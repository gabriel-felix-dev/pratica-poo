using TransportadoraTranslogica.Interfaces;

namespace TransportadoraTranslogica.Models;

public class CargaFragil(string codigoIdentificacao, double peso, decimal valorDeclarado, Cliente clienteDestinatario, string materialEmbalagem) : Carga(codigoIdentificacao, peso, valorDeclarado, clienteDestinatario), IRastreavel
{
    public string MaterialEmbalagem { get; private set; } = materialEmbalagem;
    public string CodigoRastreio { get; private set; } = $"FR-{codigoIdentificacao}";

    private double TaxaManuseio { get; set; } = 1.15;

    public string ObterInstrucoesSeguranca() => $"MANUSEIO DELICADO - Carga frágil protegida com {MaterialEmbalagem}.";

    public override void CalcularFrete()
    {
        decimal valorFrete = (decimal)Peso * 5.00m;

        valorFrete *= (decimal)TaxaManuseio;

        AtuliazarFrete(valorFrete);
    }

    public void AlterarMaterialEmbalagem(string materialEmbalagem) => MaterialEmbalagem = materialEmbalagem;

    public override string ToString() => $"Id: {Id} | Peso: {Peso} | Valor do Frete: {Frete:c} | Valor Declarado: {ValorDeclarado:c} | Cliente Destinatário: {ClienteDestinatario.Nome} | Status Operacional: {StatusOperacional} | Código Rastreio: {CodigoRastreio}";

}
