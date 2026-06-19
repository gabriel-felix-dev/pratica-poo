using TransportadoraTranslogica.Enums;
using TransportadoraTranslogica.Interfaces;

namespace TransportadoraTranslogica.Models;

public class CargaPerigosa(string codigoIdentificacao, double peso, decimal valorDeclarado, Cliente clienteDestinatario, TipoCargaPerigosaEnum tipoCargaPerigosa, ClasseRiscoEnum classeRisco, string numeroOnu) : Carga(codigoIdentificacao, peso, valorDeclarado, clienteDestinatario), IRastreavel
{
    public TipoCargaPerigosaEnum TipoCargaPerigosa { get; private set; } = tipoCargaPerigosa;
    public ClasseRiscoEnum ClasseRisco { get; private set; } = classeRisco;
    public string NumeroOno { get; private set; } = numeroOnu;
    public string CodigoRastreio { get; private set; } = $"PR-{codigoIdentificacao}";

    private decimal TaxaSeguroAmbiental { get; set; } = 150.00m;

    public override void CalcularFrete()
    {
        decimal valorFrete = (decimal)Peso * 5.00m;

        valorFrete += TaxaSeguroAmbiental;

        AtuliazarFrete(valorFrete);
    }

    public void AlterarTipoCarga(TipoCargaPerigosaEnum tipoCargaPerigosa) => TipoCargaPerigosa = tipoCargaPerigosa;

    public void AlterarClasseRisco(ClasseRiscoEnum classeRisco) => ClasseRisco = classeRisco;

    public string ObterInstrucoesSeguranca() => $"ATENÇÃO: Carga perigosa classe {ClasseRisco} (Número ONU: {NumeroOno}). Requer equipe autorizada e EPIs adequados.";

    public override string ToString() => $"Id: {Id} | Peso: {Peso} | Valor do Frete: {Frete:c} | Valor Declarado: {ValorDeclarado:c} | Cliente Destinatário: {ClienteDestinatario.Nome} | Status Operacional: {StatusOperacional} | Número Onu: {NumeroOno} | Código de Rastreio: {CodigoRastreio} | Tipo da Carga: {TipoCargaPerigosa} | Classe de Risco: {ClasseRisco}";
}
