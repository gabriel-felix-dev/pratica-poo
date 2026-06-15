namespace MedConsulta.Models;

public class Paciente(string nome, string numeroCarteirinha, string cpf, DateTime dataNascimento)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Nome { get; private set; } = nome;
    public string NumeroCarteirinha { get; private set; } = numeroCarteirinha;
    public string Cpf { get; private set; } = cpf;
    public DateTime DataNascimento { get; private set; } = dataNascimento;

    public void AlterarCpf(string cpf) => Cpf = cpf;

    public void AlterarNumeroCarteirinha(string numeroCarteirinha) => Cpf = numeroCarteirinha;

    public void AlterarDados(string nome, string numeroCarteirinha)
    {
        Nome = nome;
        NumeroCarteirinha = numeroCarteirinha;
    }

    public override string ToString() => $"Id: {Id} | Nome: {Nome} | Número Carteirinha: {NumeroCarteirinha} | Cpf: {Cpf} | Data de Nascimento: {DataNascimento:d}";
}
