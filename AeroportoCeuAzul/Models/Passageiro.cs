using AeroportoCeuAzul.Enums;

namespace AeroportoCeuAzul.Models;

public class Passageiro
{
    public Passageiro(string nome, DateTime dataNascimento, string cpf, string passaporteNumero)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        DataNascimento = dataNascimento;
        Cpf = cpf;
        PassaporteNumero = passaporteNumero;
        StatusCadastro = StatusCadastroEnum.Ativo;
    }

    public Guid Id { get; }
    public string Nome { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Cpf { get; private set; }
    public string PassaporteNumero { get; private set; }
    public StatusCadastroEnum StatusCadastro { get; private set; }

    public override string ToString() => $"Id: {Id} | Nome: {Nome} | Data de Nascimento: {DataNascimento:d} | CPF: {Cpf} | Número do Passaporte: {PassaporteNumero} | Status do Cadastro: {StatusCadastro}\n";

    public void AlteraNome(string nome) => Nome = nome;
    public void AlteraStatus(StatusCadastroEnum statusCadastro) => StatusCadastro = statusCadastro;

}
