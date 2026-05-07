using AeroportoCeuAzul.Enums;
using AeroportoCeuAzul.Interfaces;

namespace AeroportoCeuAzul.Models;

public class Passageiro : IAlterarStatusCadastro
{
    public Passageiro(string nome, DateTime dataNascimento, string cpf, string numeroPassaporte)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        DataNascimento = dataNascimento;
        Cpf = cpf;
        NumeroPassaporte = numeroPassaporte;
        StatusCadastro = StatusCadastroEnum.Ativo;
    }

    public Guid Id { get; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Cpf { get; private set; }
    public string NumeroPassaporte { get; private set; }
    public StatusCadastroEnum StatusCadastro { get; private set; }

    public void AlterarDados(string nome, DateTime dataNascimento, string cpf, string numeroPassaporte)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Cpf = cpf;
        NumeroPassaporte = numeroPassaporte;
    }

    public void AlterarStatusCadastro() => StatusCadastro = StatusCadastroEnum.Inativo;

    public override string ToString() => $"Id: {Id} | Passageiro: {Nome} | Data de Nascimento: {DataNascimento:d} | CPF: {Cpf} | Número do Passaporte: {NumeroPassaporte} | Status: {StatusCadastro}";
}
