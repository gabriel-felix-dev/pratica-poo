namespace TransportadoraTranslogica.Interfaces;

public interface IRastreavel
{
    string CodigoRastreio { get; }
    string ObterInstrucoesSeguranca();
}
