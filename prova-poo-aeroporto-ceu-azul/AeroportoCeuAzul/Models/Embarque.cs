using AeroportoCeuAzul.Enums;

namespace AeroportoCeuAzul.Models;

public class Embarque
{
    public Embarque(Passageiro passageiro, Voo voo, ClasseViagemEnum classeViagem, int numeroPoltrona)
    {
        Id = Guid.NewGuid();
        Passageiro = passageiro;
        Voo = voo;
        ClasseViagem = classeViagem;
        NumeroPoltrona = numeroPoltrona;
        DataEmissaoBilhete = DateTime.Now;
    }

    public Guid Id { get; }
    public Passageiro Passageiro { get; private set; }
    public Voo Voo { get; private set; }
    public ClasseViagemEnum ClasseViagem { get; private set; }
    public int NumeroPoltrona { get; private set; }
    public DateTime DataEmissaoBilhete { get; private set; }

    public override string ToString() => $"Id: {Id} | Voo: {Voo.CodigoUnico} | Passageiro: {Passageiro.Nome} | Passaporte: {Passageiro.NumeroPassaporte} | Classe de Viagem: {ClasseViagem} | Número da Poltrona: {NumeroPoltrona} | Data de Emissão do Bilhete: {DataEmissaoBilhete:d}";
}
